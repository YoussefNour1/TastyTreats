using Microsoft.AspNetCore.Mvc;
using TastyTreats.Models;
using TastyTreats.Repositories;

namespace TastyTreats.Controllers
{
    public class ItemController : Controller
    {
        //injection
        IItemRepository _itemRepository;
        public ItemController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        

        public IActionResult Index()
        {
            var items = _itemRepository.GetAll();
            if (items == null)
            {
                return NotFound();
            }
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
            return View(new Item());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Item item, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    string fileName = Path.GetFileNameWithoutExtension(imageFile.FileName);
                    string extension = Path.GetExtension(imageFile.FileName);
                    fileName = fileName + "_" + Guid.NewGuid().ToString() + extension;

                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        imageFile.CopyTo(stream);
                    }

                    item.ItemPicture = "/images/" + fileName;
                }
                _itemRepository.Add(item);
                _itemRepository.Save();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var item = _itemRepository.GetById(id);
            if (item != null)
            {
                return View(item);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Edit(int id, Item newItem, IFormFile imageFile)
        {
            if (newItem.Name != null)
            {
                var oldItem = _itemRepository.GetById(id);

                if (imageFile != null && imageFile.Length > 0)
                {
                    string fileName = Path.GetFileNameWithoutExtension(imageFile.FileName);
                    string extension = Path.GetExtension(imageFile.FileName);
                    fileName = fileName + "_" + Guid.NewGuid().ToString() + extension;

                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        imageFile.CopyTo(stream);
                    }

                    newItem.ItemPicture = "/images/" + fileName;
                }
                else
                {
                    newItem.ItemPicture = oldItem.ItemPicture;
                }

                oldItem.ItemPicture = newItem.ItemPicture;
                oldItem.Name = newItem.Name;
                oldItem.Price = newItem.Price;
                oldItem.Category = newItem.Category;
                oldItem.Availability = newItem.Availability;

                _itemRepository.Update(newItem);
                _itemRepository.Save();
                return RedirectToAction("Index");
            }

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
