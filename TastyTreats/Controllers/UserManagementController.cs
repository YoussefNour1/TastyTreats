using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TastyTreats.Models;
using TastyTreats.Repositories.UserRepos;
using TastyTreats.ViewModel;

namespace TastyTreats.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Route("admin/manage/users")]
    public class UserManagementController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _environment;
        private readonly RoleManager<Role> _roleManager;
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;


        public UserManagementController(UserManager<ApplicationUser> userRepository, IWebHostEnvironment environment, RoleManager<Role> roleManager, IPasswordHasher<ApplicationUser> passwordHasher)
        {
            _userManager = userRepository;
            _environment = environment;
            _roleManager = roleManager;
            _passwordHasher = passwordHasher;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = _userManager.Users.ToList();
            var userList = new List<UserWithRolesViewModel>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                userList.Add(new UserWithRolesViewModel
                {
                    User = user,
                    Roles = roles
                });
            }

            return View(userList);
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(U => U.Id == id);
            if (user == null)
            {
                return View();
            }
            var roles = await _userManager.GetRolesAsync(user);
            var userDetailsViewModel = new UserDetailsViewModel
            {
                User = user,
                Roles = roles.ToList()
            };
            return View(userDetailsViewModel);
        }

        [HttpGet("create")]
        public async Task<IActionResult> Create()
        {

            var roles = await _roleManager.Roles.ToListAsync();

            ViewBag.Roles = roles.Select(r => new SelectListItem
            {
                Value = r.Id.ToString(),
                Text = r.Name
            }).ToList();
            return View();
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ApplicationUser user, string Password, string SelectedRole, [FromForm] IFormFile? UserPicture)
        {
            if (ModelState.IsValid)
            {
                // Handle the picture upload as you already have in your original logic.
                if (UserPicture != null && UserPicture.Length > 0)
                {
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(UserPicture.FileName);
                    string uploads = Path.Combine(_environment.WebRootPath, "img/users");
                    string filePath = Path.Combine(uploads, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await UserPicture.CopyToAsync(fileStream);
                    }

                    user.UserPicture = "/img/users/" + uniqueFileName;
                }

                // Create the user in the Identity system
                var result = await _userManager.CreateAsync(user, Password);
                if (result.Succeeded)
                {
                    // Assign the selected role
                    if (!string.IsNullOrEmpty(SelectedRole))
                    {
                        var role = await _roleManager.FindByIdAsync(SelectedRole);
                        if (role != null)
                        {
                            await _userManager.AddToRoleAsync(user, role.Name);
                        }
                    }

                    return RedirectToAction(nameof(Index));
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If something goes wrong, repopulate the roles and return the view
            var roles = await _roleManager.Roles.ToListAsync();
            ViewBag.Roles = roles.Select(r => new SelectListItem
            {
                Value = r.Id.ToString(),
                Text = r.Name
            }).ToList();

            return View(user);
        }
        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return NotFound();
            }

            var roles = await _userManager.GetRolesAsync(user);
            ViewBag.Roles = new SelectList(_roleManager.Roles.ToList(), "Name", "Name", roles.FirstOrDefault());


            return View(user);
        }

        [HttpPost("Update"), ActionName("Update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, ApplicationUser user, IFormFile? UserPicture, string Role)
        {
            if (Id != user.Id)
            {
                return NotFound(new {Id, UID=user.Id});
            }

            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByIdAsync(user.Id.ToString());
                if (existingUser == null)
                {
                    return NotFound();
                }

                // Update basic user information
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                existingUser.Address = user.Address;
                existingUser.City = user.City;
                existingUser.Phone = user.Phone;
                // Handle profile picture update
                if (UserPicture != null && UserPicture.Length > 0)
                {
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(UserPicture.FileName);
                    string uploads = Path.Combine(_environment.WebRootPath, "img/users");
                    string filePath = Path.Combine(uploads, uniqueFileName);

                    // Upload the file to the server
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await UserPicture.CopyToAsync(fileStream);
                    }

                    // Update user's picture URL
                    existingUser.UserPicture = "/img/users/" + uniqueFileName;
                }

                // Update the role if it has been changed
                var currentRoles = await _userManager.GetRolesAsync(existingUser);
                if (!currentRoles.Contains(Role))
                {
                    // Remove current roles
                    await _userManager.RemoveFromRolesAsync(existingUser, currentRoles);

                    // Add new role
                    await _userManager.AddToRoleAsync(existingUser, Role);
                }

                // Update user in database
                var result = await _userManager.UpdateAsync(existingUser);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                Console.WriteLine(result.Errors.ToList());
            }
            var roles = await _roleManager.Roles.ToListAsync();
            ViewBag.Roles = roles.Select(r => new SelectListItem
            {
                Value = r.Id.ToString(),
                Text = r.Name,
            }).ToList();

            return RedirectToAction(nameof(Edit), new {id=user.Id});
        }


        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(U=> U.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost("DeleteConfirmed"), ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(U => U.Id == id);
            try
            {
                await _userManager.DeleteAsync(user);
            }
            catch (Exception ex) { 
                return NotFound(ex.Message);
            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}
