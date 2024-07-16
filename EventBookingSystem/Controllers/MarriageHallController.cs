using EventBookingSystem.Common;
using EventBookingSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventBookingSystem.Controllers
{
    public class MarriageHallController : Controller
    {
        private readonly EventDbContext _db;

        public MarriageHallController(EventDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<MarriageHall> x = _db.MarriageHalls.ToList();
            return View(x);
        }
        public IActionResult Marriage()
        {
            //User x = HttpContext.Session.GetObjectFromJson<User>("login");

            //if (x == null)
            //{
            //    return RedirectToAction("Index", "Home");
            //}

            ViewBag.services=_db.Servicess.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Save(MarriageHall h)
        {

            User x = HttpContext.Session.GetObjectFromJson<User>("login");
            if (x == null)
            {
                return RedirectToAction("Index", "Home");
            }
            h.UserId = x.Id;

            if (h.Id> 0)
            {
                _db.MarriageHalls.Update(h);
            }
            else
            {
                _db.MarriageHalls.Add(h);
                _db.SaveChanges();
                foreach (var item in h.MarriageHallServices)
                {
                    item.MarriageHallId = h.Id;
                    _db.MarriageHallServices.Add(item);
                }
            }
         
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            MarriageHall x = _db.MarriageHalls.Find(id);
            return View("Marriage", x);
        }
        public IActionResult Delete(int id)
        {
            MarriageHall x = _db.MarriageHalls.Find(id);
            _db.MarriageHalls.Remove(x);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
