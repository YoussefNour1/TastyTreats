using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TastyTreats.Controllers
{
    //[Authorize(Roles = "admin")]

    public class OrderManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
