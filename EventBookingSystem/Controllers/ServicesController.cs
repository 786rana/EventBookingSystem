using EventBookingSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventBookingSystem.Controllers
{
    public class ServicesController : Controller
    {
        private readonly EventBookingSystemOrg10Context _db;
        public ServicesController(EventBookingSystemOrg10Context db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Servicess> x = _db.Servicesses.ToList();
            return View(x);
        }
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Save(Servicess x) 
        {
            if (x.Id> 0) 
            {
                _db.Servicesses.Update(x);
            }
            else
            {
                _db.Servicesses.Add(x);
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            Servicess x = _db.Servicesses.Find(id);
            return View("Create", x);

        }
        public IActionResult Delete(int id) 
        {
            Servicess x = _db.Servicesses.Find(id);
            _db.Servicesses.Remove(x);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        

    }
}
