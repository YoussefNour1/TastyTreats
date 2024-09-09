using Microsoft.AspNetCore.Mvc;
using TastyTreats.Models;
using TastyTreats.Repositories;

namespace TastyTreats.Controllers
{
    public class CartItemController : Controller
    {
        
        private readonly ICartItemRepository _cartItemRepository;

        //Make asking process and Injection
        public CartItemController(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        //This Action to get all CartItems that includes actual items from the database
        public IActionResult Index()
        {
            var CartItems = _cartItemRepository.GetAllCartItems();
            return View(CartItems);
        }


        //This Action to get a specific CartItem from the Cart based on CartItemId
        public IActionResult Details(int id)
        {   var CartItem = _cartItemRepository.GetCartItemById(id);
            if (CartItem == null)
            {
                return NotFound();
            }
            return View(CartItem);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Add new CartItem 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CartItem cartItem)
        {
            if (ModelState.IsValid)
            {
                _cartItemRepository.CreateCartItem(cartItem);
                _cartItemRepository.Save();
                return RedirectToAction("Index");
            }
            return View(cartItem);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var cartItem = _cartItemRepository.GetCartItemById(id);
            if (cartItem == null)
            {
                return NotFound();
            }
            return View(cartItem);
        }


        //Update on an existance CartItems
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CartItem newcartItem)
        {
            if (ModelState.IsValid)
            {    
                var oldcartItem = _cartItemRepository.GetCartItemById(id);
                oldcartItem.Quantity = newcartItem.Quantity;
                oldcartItem.Price = newcartItem.Price;
                _cartItemRepository.UpdateCartItem(newcartItem);
                _cartItemRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(newcartItem);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var cartItem = _cartItemRepository.GetCartItemById(id);
            if (cartItem == null)
            {
                return NotFound();
            }
            return View(cartItem);
        }

        //Delete on an existance CartItems
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _cartItemRepository.DeleteCartItem(id);
            _cartItemRepository.Save();
            return RedirectToAction("Index");
        }

    }
}
