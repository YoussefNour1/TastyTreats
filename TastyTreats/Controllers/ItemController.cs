using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TastyTreats.Models;
using TastyTreats.Repositories.ItemRepos;

namespace TastyTreats.Controllers
{
    [Authorize(Roles = "admin")]
    public class ItemController : Controller
    {
        //injection
        IItemRepository _itemRepository;
        public ItemController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }


        //public IActionResult Index()
        //{
        //    var items = _itemRepository.GetAll();
        //    if (items == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(items);
        //}


        public IActionResult Index(int pageNumber = 1, int pageSize = 10, string searchTerm = "")
        {
            var items = _itemRepository.GetAll(pageNumber, pageSize, searchTerm); // Update to pass search term
            if (items == null || !items.Any())
            {
                return NotFound();
            }

            // Total items for pagination logic
            int totalItems = _itemRepository.CountItems(searchTerm); // Update to count based on search term
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            ViewBag.CurrentPage = pageNumber;
            ViewBag.SearchTerm = searchTerm; // Pass search term to the view

            return View(items);
        }

        public IActionResult Details(int id)
        {
            var item = _itemRepository.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            
            return View(item);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Categ = new SelectList(_itemRepository.GetCategories().ToList(), "CategoryId", "Name");
            return View(new Item());
        }

        [HttpPost]
        public IActionResult Add(Item item, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    string fileName = Path.GetFileNameWithoutExtension(imageFile.FileName);
                    string extension = Path.GetExtension(imageFile.FileName);
                    fileName = fileName + "_" + Guid.NewGuid().ToString() + extension;

                    string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    string path = Path.Combine(folderPath, fileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        imageFile.CopyTo(stream);
                    }
                    item.ItemPicture = "/img/" + fileName;
                }

                _itemRepository.Add(item);
                _itemRepository.Save();

                return RedirectToAction("Index");
            }

            ViewBag.Categ = new SelectList(_itemRepository.GetCategories(), "CategoryId", "Name");
            return View(item);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var item = _itemRepository.GetById(id);
            if (item == null)
            {
                return NotFound();
            }

            ViewBag.Categ = new SelectList(_itemRepository.GetCategories().ToList(), "CategoryId", "Name", item.CategoryId);
            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(int id, Item newItem, IFormFile? imageFile)
        {
            if (ModelState.IsValid)
            {
                var oldItem = _itemRepository.GetById(id);
                if (oldItem == null)
                {
                    return NotFound();
                }

                if (imageFile != null && imageFile.Length > 0)
                {
                    string fileName = Path.GetFileNameWithoutExtension(imageFile.FileName);
                    string extension = Path.GetExtension(imageFile.FileName);
                    fileName = fileName + "_" + Guid.NewGuid().ToString() + extension;

                    string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    string path = Path.Combine(folderPath, fileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        imageFile.CopyTo(stream);
                    }
                    newItem.ItemPicture = "/img/" + fileName;
                }
                else
                {
                   newItem.ItemPicture =oldItem.ItemPicture;
                }

                oldItem.Name = newItem.Name;
                oldItem.Price = newItem.Price;
                oldItem.Discount = newItem.Discount;
                oldItem.Description = newItem.Description;
                oldItem.CategoryId = newItem.CategoryId;
                oldItem.Availability = newItem.Availability;

                _itemRepository.Update(oldItem);
                _itemRepository.Save();

                return RedirectToAction("Index");
            }

            ViewBag.Categ = new SelectList(_itemRepository.GetCategories(), "CategoryId", "Name", newItem.CategoryId);
            return View(newItem);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var item = _itemRepository.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Deleted(int id)
        {
            _itemRepository.Delete(id);
            _itemRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
