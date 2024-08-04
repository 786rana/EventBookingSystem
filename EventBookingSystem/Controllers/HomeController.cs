using EventBookingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EventBookingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EventBookingSystemOrg10Context _db;

        public HomeController(EventBookingSystemOrg10Context db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var marriageHalls = _db.MarriageHalls.ToList();
            var services = _db.Servicesses.ToList();
            ViewBag.services = services;
            ViewBag.TotalServices = services.Count();

            ViewBag.TotalMarriageHall = marriageHalls.Count();
            ViewBag.TotalUsers = _db.Users.Count();
            var currentDate = DateTime.Now;
            ViewBag.BookedHall = _db.Orders.Where(x => currentDate >= x.StartDate && x.EndDate < currentDate).Count();

            ViewBag.MarriageHall = marriageHalls;
            return View(marriageHalls);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            var hall = _db.MarriageHalls.ToList();
            ViewBag.MarriageHall = hall;
            return View();
        }

        public IActionResult MarriageHall()
        {
            var hall = _db.MarriageHalls.ToList();
            ViewBag.MarriageHall = hall;
            return View(hall);
        }
        public IActionResult Service()
        {
            var hall = _db.MarriageHalls.ToList();
            ViewBag.MarriageHall = hall;

            var services = _db.Servicesses.ToList();
            return View(services);
        }

        public IActionResult Team()
        {
            var hall = _db.MarriageHalls.ToList();
            ViewBag.MarriageHall = hall;
            return View();
        }
        public IActionResult Contact()
        {
            var hall = _db.MarriageHalls.ToList();
            ViewBag.MarriageHall = hall;
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}