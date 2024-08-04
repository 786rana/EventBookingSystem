using EventBookingSystem.Common;
using EventBookingSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventBookingSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly EventBookingSystemOrg10Context _db;

        public AccountController(EventBookingSystemOrg10Context db)
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

        public IActionResult Logout()
        {
            HttpContext.Session.SetObjectAsJson("login", null);
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult User(User a)
        {
            var alreadyExist = _db.Users.Where(x => x.Email == a.Email).FirstOrDefault();
            if (alreadyExist==null)
            {

                _db.Users.Add(a);
                _db.SaveChanges();
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.Error = "Email Already Exist";
                return View(a);
            }
            //var db = new EventDbContext();
        }
        public IActionResult List(User a)
        {
            User x = HttpContext.Session.GetObjectFromJson<User>("login");
            if (x == null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (x.Email == "admin@gmail.com")
            {
                var users = _db.Users.ToList();
                return View(users);
            }
            var hall = _db.MarriageHalls.ToList();
            ViewBag.MarriageHall = hall;
            return RedirectToAction("Index", "Home");
        }

    }
}
