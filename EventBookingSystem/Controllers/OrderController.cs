using EventBookingSystem.Common;
using EventBookingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            User user = HttpContext.Session.GetObjectFromJson<User>("login");
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<Order> orders = _db.Orders.Where(x => x.UserId == user.Id).ToList();
            return View(orders);
        }
        public IActionResult Create()
        {
            ViewBag.services = _db.Servicesses.ToList();
            var marriageHalls = _db.MarriageHalls.ToList();
            ViewBag.MarriageHalls = new SelectList(marriageHalls, "Id", "Name");
            return View();
        }
        public IActionResult Edit(int Id)
        {
            var order = _db.Orders.Include(x => x.OrderDetails).Where(x => x.Id == Id).FirstOrDefault();

            ViewBag.MarriageHalls = _db.MarriageHalls.ToList();
            ViewBag.services = _db.Servicesses.ToList();

            return View("Create", order);
        }

        public IActionResult Order(Order model)
        {
            User x = HttpContext.Session.GetObjectFromJson<User>("login");
            if (x == null)
            {
                return RedirectToAction("Index", "Home");
            }
            model.UserId = x.Id;
            model.CreatedDate = DateTime.Now;
            if (model.Id > 0)
            {
                _db.Orders.Update(model);
            }
            else
            {
                _db.Orders.Add(model);

            }

            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult Delete(int id)
        {
            Order x = _db.Orders.Find(id);
            _db.Orders.Remove(x);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
