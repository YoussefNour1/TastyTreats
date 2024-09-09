using Microsoft.AspNetCore.Mvc;
using TastyTreats.Models;
using TastyTreats.Repositories.UserRepos;

namespace TastyTreats.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register() => View();
    }
}
