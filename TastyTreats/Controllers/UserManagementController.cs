using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TastyTreats.Models;
using TastyTreats.Repositories.UserRepos;

namespace TastyTreats.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Route("admin/manage/users")]
    public class UserManagementController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IWebHostEnvironment _environment;

        public UserManagementController(IUserRepository userRepository, IWebHostEnvironment environment)
        {
            _userRepository = userRepository;
            _environment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return View(users);
        }
        [HttpGet("details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return View();
            }
            return View(user);
        }
        [HttpGet("create")]
        public IActionResult Create()
        {
            var roles = Enum.GetValues(typeof(UserRole))
                    .Cast<UserRole>()
                    .Select(r => new SelectListItem
                    {
                        Value = ((int)r).ToString(),
                        Text = r.ToString()
                    }).ToList();

            ViewBag.Roles = roles;
            return View();
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create(User user,[FromForm] IFormFile? UserPicture)
        {
            if (ModelState.IsValid)
            {
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

                await _userRepository.AddUserAsync(user);
                return RedirectToAction(nameof(Index));
            }
            var roles = Enum.GetValues(typeof(UserRole))
                    .Cast<UserRole>()
                    .Select(r => new SelectListItem
                    {
                        Value = ((int)r).ToString(),
                        Text = r.ToString()
                    }).ToList();

            ViewBag.Roles = roles;
            return View(user);
        }

        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var roles = Enum.GetValues(typeof(UserRole))
                    .Cast<UserRole>()
                    .Select(r => new SelectListItem
                    {
                        Value = ((int)r).ToString(),
                        Text = r.ToString()
                    }).ToList();

            ViewBag.Roles = roles;
            return View(user);
        }

        [HttpPost("edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int UserId, User user, IFormFile? UserPicture)
        {
            if (UserId != user.UserId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
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

                await _userRepository.UpdateUserAsync(user);
                return RedirectToAction(nameof(Index));
            }
            var roles = Enum.GetValues(typeof(UserRole))
                    .Cast<UserRole>()
                    .Select(r => new SelectListItem
                    {
                        Value = ((int)r).ToString(),
                        Text = r.ToString()
                    }).ToList();

            ViewBag.Roles = roles;
            return View(user);
        }

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _userRepository.DeleteUserAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
