using Microsoft.AspNetCore.Mvc;
using TastyTreats.Models;
using TastyTreats.Repositories;

namespace TastyTreats.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepository;

        //Asking and Injection process
        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        // This Action for getting All Carts in the database
        public IActionResult Index()
        {
            var carts = _cartRepository.GetAllCarts();
            if(carts ==null)
            {
                return NotFound();
            }
            return View(carts);
        }

        //This Action for getting a specified cart based on CartId
        public IActionResult Details(int id)
        {
            var cart = _cartRepository.GetCartById(id);
            if (cart == null)
            {
                return NotFound();
            }
            return View(cart);
        }

        [HttpGet]
        //This Action for creating new cart
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //This Action for creating new cart if Modelstate == true
        public IActionResult Create(Cart cartobj)
        {
            if (ModelState.IsValid)
            {
                _cartRepository.CreateCart(cartobj);
                _cartRepository.Save();
                return RedirectToAction("Index");
            }
            return View(cartobj);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var cart = _cartRepository.GetCartById(id);
            if (cart == null)
            {
                return NotFound();
            }
            return View(cart);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        //This Action for Updating at existance cart if ModelState == true
        public IActionResult Edit(int id, Cart newcart)
        {
            if (ModelState.IsValid)
            {   var oldcart = _cartRepository.GetCartById(id);
                oldcart.Quantity = newcart.Quantity;
                _cartRepository.UpdateCart(newcart);
                _cartRepository.Save();
                return RedirectToAction("Index");
            }
            return View(newcart);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var cart = _cartRepository.GetCartById(id);
            if (cart == null)
            {
                return NotFound();
            }
            return View(cart);
        }

        // POST: Cart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _cartRepository.DeleteCart(id);
            _cartRepository.Save();
            return RedirectToAction("Index");
        }

    }
}
