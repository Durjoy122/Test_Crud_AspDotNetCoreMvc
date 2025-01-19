using Microsoft.AspNetCore.Mvc;
using TestProject.Data;
using TestProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace TestProject.Controllers
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
            List<Category> obj = _db.Myproperties.ToList();
            return View(obj);
        }

        public IActionResult Create()
        {
            return View(); //This will return the view page where we can create a new category
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if(ModelState.IsValid)
            {
                _db.Myproperties.Add(category);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Myproperties.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var obj = _db.Myproperties.Find(id);
            if(obj  == null)
            {
                return NotFound();
            }
            _db.Myproperties.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
