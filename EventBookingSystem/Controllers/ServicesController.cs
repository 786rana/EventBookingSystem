using EventBookingSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventBookingSystem.Controllers
{
    public class ServicesController : Controller
    {
        private readonly EventDbContext _db;
        public ServicesController(EventDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Services> x = _db.Servicess.ToList();
            return View(x);
        }
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Save(Services x) 
        {
            if (x.Id> 0) 
            {
                _db.Servicess.Update(x);
            }
            else
            {
                _db.Servicess.Add(x);
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            Services x = _db.Servicess.Find(id);
            return View("Create", x);

        }
        public IActionResult Delete(int id) 
        {
            Services x = _db.Servicess.Find(id);
            _db.Servicess.Remove(x);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        

    }
}
