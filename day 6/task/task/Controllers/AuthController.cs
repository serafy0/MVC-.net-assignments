using Microsoft.AspNetCore.Mvc;
using task.Context;
using task.Models;

namespace task.Controllers
{
    public class AuthController : Controller
    {
        private readonly ITIContext _context;

        public AuthController(ITIContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserEmail") != null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = _context.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);

                if (existingUser != null)
                {
                    HttpContext.Session.SetString("UserEmail", existingUser.Email);
                    return RedirectToAction("Index");
                }
                else
                {
                    user.Password = user.Password; // Use hashing in real scenarios
                    _context.Users.Add(user);
                    _context.SaveChanges();
                    HttpContext.Session.SetString("UserEmail", user.Email);
                    return RedirectToAction("Index");
                }
            }
            return View(user);
        }

        public IActionResult Index()
        {
            var userEmail = HttpContext.Session.GetString("UserEmail");

            if (string.IsNullOrEmpty(userEmail))
            {
                return RedirectToAction("Login");
            }

            var user = _context.Users.FirstOrDefault(u => u.Email == userEmail);

            return View(user);
        }

        public IActionResult Edit(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Update(user);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = _context.Users.FirstOrDefault(u => u.Email == user.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError("Email", "This email is already registered.");
                    return View(user);
                }

                _context.Users.Add(user);
                _context.SaveChanges();

                HttpContext.Session.SetInt32("UserID", user.ID);
                HttpContext.Session.SetString("UserEmail", user.Email);

                return RedirectToAction("Index");
            }

            return View(user);
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
