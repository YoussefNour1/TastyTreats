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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Item item)
        {
            if (ModelState.IsValid)
            {
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
        public IActionResult Edit(int id, Item newitem)
        {
            if(newitem.Name!=null)
            {
                var olditem = _itemRepository.GetById(id);
                olditem.ItemPicture = newitem.ItemPicture;
                olditem.Name = newitem.Name;
                olditem.Price = newitem.Price;
                olditem.Category = newitem.Category;
                olditem.Availability = newitem.Availability;

                _itemRepository.Update(newitem);
                _itemRepository.Save();
                return RedirectToAction("Index");
            }
            
            return View(newitem);
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
