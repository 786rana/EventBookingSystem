using EventBookingSystem.Common;
using EventBookingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventBookingSystem.Controllers
{
    public class MarriageHallController : Controller
    {
        private readonly EventBookingSystemOrg10Context _db;

        public MarriageHallController(EventBookingSystemOrg10Context db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            User user = HttpContext.Session.GetObjectFromJson<User>("login");
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<MarriageHall> x = _db.MarriageHalls.Where(x => x.UserId == user.Id).ToList();
            return View(x);
        }
        public IActionResult Marriage()
        {
            //User x = HttpContext.Session.GetObjectFromJson<User>("login");

            //if (x == null)
            //{
            //    return RedirectToAction("Index", "Home");
            //}

            ViewBag.services=_db.Servicesses.ToList();
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
            }
         
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            ViewBag.services = _db.Servicesses.ToList();
            MarriageHall x = _db.MarriageHalls.Include(x=>x.MarriageHallServices).Where(x=>x.Id==id).FirstOrDefault();
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
