using EventBookingSystem.Common;
using EventBookingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventBookingSystem.Controllers
{

    public class OrderController : Controller
    {
        private readonly EventBookingSystemOrg10Context _db;

        public OrderController(EventBookingSystemOrg10Context db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Order> x = _db.Orders.ToList();
            return View(x);
        }
        public IActionResult Create ()
        {
            ViewBag.services = _db.Servicesses.ToList();
            ViewBag.MarriageHalls = _db.MarriageHalls.ToList();
          

            return View();
        }   
        public IActionResult Order(Order a)
        {
            User x = HttpContext.Session.GetObjectFromJson<User>("login");
            if (x == null)
            {
                return RedirectToAction("Index", "Home");
            }
            a.UserId = x.Id;

            if (a.Id > 0)
            {
                _db.Orders.Update(a);
            }
            else
            {
                _db.Orders.Add(a);
                _db.SaveChanges();
            }

            _db.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Edit(int id) 
        {
            ViewBag.servicess = _db.Servicesses.ToList();
            ViewBag.MarriageHalls = _db.MarriageHalls.ToList();
            return View();
        }
        public IActionResult Delete(int id)
        {
            Order x= _db.Orders.Find(id);
            _db.Orders.Remove(x);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}
