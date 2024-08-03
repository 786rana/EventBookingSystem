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
            return View(marriageHalls);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}