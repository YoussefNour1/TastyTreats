using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TastyTreats.Models;
using TastyTreats.Repositories.OrderRepos;

namespace TastyTreats.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public CheckoutController(IOrderRepository orderRepository, UserManager<ApplicationUser> userManager)
        {
            _orderRepository = orderRepository;
            _userManager = userManager;
        }

        // GET: Checkout
        public IActionResult Index()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
            var user = _userManager.FindByIdAsync(userId).Result; // Get authenticated user info
            return View(user);
        }

        // POST: Update User Info and Confirm Order
        [HttpPost]
        public async Task<IActionResult> ConfirmOrderAndUpdateUser(string address, string phone)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
            var user = await _userManager.FindByIdAsync(userId);

            // Update user information
            if (user != null)
            {
                user.Address = address;
                user.Phone = phone;
                var updateResult = await _userManager.UpdateAsync(user);

                if (!updateResult.Succeeded)
                {
                    TempData["ErrorMessage"] = "Error updating user information.";
                    return RedirectToAction("Index");
                }
            }

            // Confirm order
            try
            {
                var order = await _orderRepository.Add(int.Parse(userId));
                TempData["SuccessMessage"] = "Order confirmed successfully!";

                return RedirectToAction("Index", "Order");
            }
            catch (InvalidOperationException ex)
            {
                // Handle the case where the cart is empty or does not exist
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index", "Cart");
            }
        }

        // Action for displaying order confirmation
        public IActionResult OrderConfirmation(int orderId)
        {
            var order = _orderRepository.Details(orderId);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }
    }
}
