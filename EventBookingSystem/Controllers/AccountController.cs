using EventBookingSystem.Common;
using EventBookingSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventBookingSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly EventDbContext _db;

        public AccountController(EventDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User x)
        {
            User user = _db.Users.Where(m => m.Email == x.Email && m.Password == x.Password).FirstOrDefault();
            if (ModelState.IsValid) { }
            if (user == null)
            {
                ViewBag.error = "Incorrect Email or password";
                return View(x);
            }
            else
            {
                HttpContext.Session.SetObjectAsJson("login", user);
                return RedirectToAction("Index", "Home");
            }   
        }
        public IActionResult User()
        {
            return View();
        }
        [HttpPost]
        public IActionResult User(User a)
        {
            //var db = new EventDbContext();
            _db.Users.Add(a);
            _db.SaveChanges();
            return RedirectToAction("Login");
        }
    }
}
