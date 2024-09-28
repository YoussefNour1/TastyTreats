using Microsoft.AspNetCore.Mvc;
using TastyTreats.Models;
using TastyTreats.Repositories;

namespace TastyTreats.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepository;
        private readonly IItemRepository _itemRepository;

       //Asking and Injection process
       public CartController(ICartRepository cartRepository, IItemRepository itemRepository)
        {
            _cartRepository = cartRepository;
            _itemRepository = itemRepository;
        }


        //This Action to Display cart details for a specific user by cart ID and User ID
        [HttpGet]
        [Route("Cart/Details/{userId}")]
        public async Task<IActionResult> Details(int userId)
        {
            var cart =await _cartRepository.GetCartByUserId(userId);
            return View(cart);
        }


        //This method for create cart for User and Add a new item to the cart
        [HttpPost]
        public async Task<IActionResult> CreateAndAddCartItem(int userId, int itemId, int quantity)
        {
            if (quantity <= 0)
            {
                ModelState.AddModelError("Quantity", "Quantity must be greater than 0.");
                TempData["ErrorMessage"] = "Invalid quantity. Must be greater than 0.";
                return RedirectToAction("Details", "Item", new { id = itemId }); // Redirect back to the item details view with error
            }

            // Prepare the CartItem
            var cartItem = new CartItem
            {
                ItemId = itemId,
                Quantity = quantity,
            };

            // Create cart for user and add cart item to the cart
            var cartItemResult = await _cartRepository.AddCartItem(userId, cartItem);

            if (cartItemResult == null)
            {
                TempData["ErrorMessage"] = "Failed to add the item to the cart.";
                return RedirectToAction("Details", "Item", new { id = itemId }); // Redirect back with error
            }

            TempData["SuccessMessage"] = "Item successfully added to the cart!";
            return RedirectToAction("Details", "Item", new { id = itemId }); // Redirect back to the item details view with success
        }



        // Update the quantity of a cart item
        [HttpPost]
        public async Task<IActionResult> UpdateCartItemQuantity(int cartItemId, int newQuantity)
        {
            if (newQuantity <= 0)
            {
                TempData["ErrorMessage"] = "Quantity must be greater than 0.";
                return NotFound("Invalid quantity.");
            }

            var cartItemResult = await _cartRepository.UpdateCartItemQuantity(cartItemId, newQuantity);

            if (cartItemResult == null)
            {
                TempData["ErrorMessage"] = "Failed to update the cart item quantity.";
                return NotFound("CartItem not found.");
            }

            TempData["SuccessMessage"] = "Cart item quantity updated successfully!";
            return RedirectToAction("Details", new { userId = cartItemResult.Cart.UserId });
        }


        // Remove an item from the cart
        [HttpPost]
        public async Task<IActionResult> RemoveCartItem(int cartItemId)
        {
            var cartItem = await _cartRepository.RemoveCartItem(cartItemId);

            if (cartItem == null)
            {
                TempData["ErrorMessage"] = "Failed to remove the item from the cart.";
                return NotFound("CartItem not found.");
            }

            TempData["SuccessMessage"] = "Item successfully removed from the cart!";

            var cart = await _cartRepository.GetCartByUserId(cartItem.Cart.UserId);
            if (cart == null)
            {
                TempData["ErrorMessage"] = "Cart not found.";
                return NotFound();
            }

            return RedirectToAction("Details", new { userId = cartItem.Cart.UserId });
        }

    }
}
