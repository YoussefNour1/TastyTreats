using Microsoft.AspNetCore.Mvc;

namespace TastyTreats.Controllers
{
    public class RoleManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
