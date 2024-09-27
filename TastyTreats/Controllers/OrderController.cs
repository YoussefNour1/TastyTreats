using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using TastyTreats.Models;
using TastyTreats.Repositories.OrderRepos;

namespace TastyTreats.Controllers
{
    public class OrderController : Controller
    {
        private readonly  IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public IActionResult Index()
        {
           var ords= _orderRepository.GetAll();
            return View(ords);
        }
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var data= _orderRepository.Details(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }
        


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int UserId)
        {
            if (ModelState.IsValid)
            {
                await _orderRepository.Add(UserId);
                 //_orderRepository.Save();

                TempData["success"] = "Order Added successfully";

                return RedirectToAction("Index");
            }

            return View();
        }
        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            Order? data = _orderRepository.GetById(Id);
            return View(data);
        }
        [HttpPost]

        public IActionResult Edit(Order Order)
        {
            if (ModelState.IsValid)
            {
                _orderRepository.Update(Order);
                _orderRepository.Save();
                TempData["success"] = "Order Updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]

        public IActionResult Delete(int? Id)
        {

          
            _orderRepository.Delete(Id);
            _orderRepository.Save();
            TempData["success"] = "Order Deleted successfully";
            return RedirectToAction("Index");
        }

    }
}
