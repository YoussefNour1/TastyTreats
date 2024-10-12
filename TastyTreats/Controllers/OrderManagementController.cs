using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TastyTreats.Repositories.OrderRepos;

namespace TastyTreats.Controllers
{
    [Authorize(Roles = "admin")]

    public class OrderManagementController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrderManagementController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IActionResult Index()
        {
           var orders= _orderRepository.GetAll(true);
            _orderRepository.Save();
            return View(orders);
        }
        [HttpPost]
        public IActionResult UpdateStatus(int orderId, string orderStatus)
        {
            var order = _orderRepository.GetById(orderId);
            if (order != null)
            {
                order.OrderStatus = orderStatus;
                order.UpdatedAt = DateTime.Now;
                _orderRepository.Save();
                TempData["success"] = "status Uppdated successfully";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
