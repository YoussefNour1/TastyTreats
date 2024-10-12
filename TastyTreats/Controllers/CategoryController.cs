using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TastyTreats.Models;
using TastyTreats.Repositories;

namespace TastyTreats.Controllers
{

    [Authorize(Roles = "admin")]
    public class CategoryController : Controller
    {
        ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var Catg = _categoryRepository.GetAll();
            if (Catg == null)
            {
                return NotFound();
            }
            return View(Catg);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Category newCatg)
        {
            if(ModelState.IsValid)
            {
                _categoryRepository.Add(newCatg);
                _categoryRepository.Save();
                return RedirectToAction("Index");
            }
            return View(newCatg);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var catg = _categoryRepository.GetById(id);
            if (catg != null)
            {
                return View(catg);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Edit(int id, Category newCatg)
        {
            if(newCatg.Name != null)
            {
                var oldCatg = _categoryRepository.GetById(id);
                oldCatg.Name = newCatg.Name;
                oldCatg.Description = newCatg.Description;

                _categoryRepository.Update(oldCatg);
                _categoryRepository.Save();
                return RedirectToAction("Index");
            }
            return View(newCatg);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var catg = _categoryRepository.GetById(id);
            if(catg == null)
            {
                return NotFound();
            }
            return View(catg);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Deleted(int id)
        {
            var catg = _categoryRepository.GetById(id);
            if(catg != null)
            {
                _categoryRepository.Delete(id);
                _categoryRepository.Save();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
