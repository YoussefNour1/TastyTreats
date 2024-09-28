using Microsoft.AspNetCore.Mvc;

namespace TastyTreats.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
