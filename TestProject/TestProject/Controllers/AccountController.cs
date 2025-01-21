using Microsoft.AspNetCore.Mvc;
using TestProject.Data;
using TestProject.Models;
using System.Linq;

namespace TestProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AccountController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registration(Users user)
        {
            if (ModelState.IsValid)
            {
                _db.Users.Add(user);
                _db.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(user);
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Users user)
        {
            var usr = _db.Users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
            if (usr != null)
            {
                // Set session or cookie here
                return RedirectToAction("Index", "Category");
            }
            else
            {
                var userExists = _db.Users.Any(u => u.Username == user.Username);
                if (!userExists)
                {
                    return RedirectToAction("Registration");
                }
            }
            ModelState.AddModelError("", "Username or Password is incorrect");
            return View("Login");
        }

    }
}
