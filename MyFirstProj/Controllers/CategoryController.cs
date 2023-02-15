using Microsoft.AspNetCore.Mvc;
using MyFirstProj.Data;
using MyFirstProj.Models;

namespace MyFirstProj.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objListOfCategory = _db.Categories;
            return View(objListOfCategory);
        }

        //get
        public IActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Name cannot exactly match the DisplayOrder");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Create Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        //get
        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var categoryItem = _db.Categories.Find(id);
            if (categoryItem == null) 
            { 
                return NotFound();
            }
            return View(categoryItem);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Name cannot exactly match the DisplayOrder");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Edit Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var categoryItem = _db.Categories.Find(id);
            if (categoryItem == null)
            {
                return NotFound();
            }
            return View(categoryItem);
        }

        //Post
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id)
        {
            var categoryItem = _db.Categories.Find(id);
            if (categoryItem == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(categoryItem);
            _db.SaveChanges();
            TempData["success"] = "Category Delete Successfully";
            return RedirectToAction("Index");
        }
    }
}
