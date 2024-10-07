using TastyTreats.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TastyTreats.ViewModel;
using Microsoft.AspNetCore.Authorization;


namespace TastyTreats.Controllers
{
    [Authorize(RoleCont)]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        public RoleController(RoleManager<IdentityRole<int>> roleManeger)
        {
            _roleManager = roleManeger;
        }

        [HttpGet]
        public IActionResult AddRole() => View();
        [HttpPost]
        public async Task<IActionResult> AddRole(AddRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole<int> identityRole = new IdentityRole<int>()
                {
                    Name = model.Name,
                };
                var result = await _roleManager.CreateAsync(identityRole);
                if (result.Succeeded)
                {
                    ViewBag.success = true;
                    return View();
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);

                }
            }
            return View(model);
        }

    }
}

