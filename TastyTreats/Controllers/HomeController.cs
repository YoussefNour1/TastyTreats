using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Drawing.Printing;
using TastyTreats.Models;
using TastyTreats.Repositories;
using TastyTreats.Repositories.ItemRepos;
using TastyTreats.ViewModel;

namespace TastyTreats.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IItemRepository _itemRepository;
        private readonly ICategoryRepository _categoryRepository;
        public HomeController(ILogger<HomeController> logger, IItemRepository itemRepository, ICategoryRepository categoryRepository )
        {
            _logger = logger;
            _itemRepository = itemRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 2, string searchTerm = "All")
        {
            var items = _itemRepository.GetAll(pageNumber, pageSize, searchTerm); // Get items
            var categories = _categoryRepository.GetAll(); // Get categories

            if (items == null || !items.Any())
            {
                return NotFound();
            }

            // Total items for pagination logic
            int totalItems = _itemRepository.CountItems(searchTerm); // Count based on search term
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            ViewBag.CurrentPage = pageNumber;
            ViewBag.SearchTerm = searchTerm; // Pass search term to the view

            // Create a ViewModel instance
            var viewModel = new ItemCategoryViewModel
            {
                Items = items,
                Categories = categories
            };

            return View(viewModel); // Pass the ViewModel to the view
        }





        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
