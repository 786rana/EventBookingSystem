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
            var hall = _db.MarriageHalls.ToList();
            ViewBag.MarriageHall = hall;
            if (user.Email == "admin@gmail.com")
            {
                List<Order> orders = _db.Orders.Include(x => x.User).ToList();
                return View(orders);
            }
            else
            {
                List<Order> orders = _db.Orders.Include(x => x.User).Where(x => x.UserId == user.Id).ToList();
                return View(orders);
            }
        }
        public IActionResult Create()
        {
            ViewBag.services = _db.Servicesses.ToList();
            var marriageHalls = _db.MarriageHalls.ToList();
            ViewBag.MarriageHalls = new SelectList(marriageHalls, "Id", "Name");

            ViewBag.MarriageHall = marriageHalls;
            return View();
        }
        public IActionResult Edit(int Id, string type = "")
        {
            var order = _db.Orders.Include(x => x.OrderDetails).Where(x => x.Id == Id).FirstOrDefault();

            var marriageHalls = _db.MarriageHalls.ToList();
            ViewBag.MarriageHalls = new SelectList(marriageHalls, "Id", "Name");
            ViewBag.services = _db.Servicesses.ToList();
            ViewBag.Type = type;
            ViewBag.MarriageHall = marriageHalls;
            return View("Create", order);
        }
        public IActionResult Details(int Id)
        {
            var order = _db.Orders.Include(x => x.OrderDetails).Where(x => x.Id == Id).FirstOrDefault();

            var marriageHalls = _db.MarriageHalls.ToList();
            ViewBag.MarriageHalls = new SelectList(marriageHalls, "Id", "Name");
            ViewBag.services = _db.Servicesses.ToList();
            ViewBag.MarriageHall = marriageHalls;
            return View(order);
        }

        
        public IActionResult Payment(int Id)
        {
            var order = _db.Orders.Include(x => x.OrderDetails).Where(x => x.Id == Id).FirstOrDefault();

            var marriageHalls = _db.MarriageHalls.ToList();
            ViewBag.MarriageHalls = new SelectList(marriageHalls, "Id", "Name");
            ViewBag.services = _db.Servicesses.ToList();

            ViewBag.MarriageHall = marriageHalls;
            return View(order);
        }
        [HttpPost]
        public IActionResult Payment(Order order)
        {
            var oldOrder = _db.Orders.Include(x => x.OrderDetails).Where(x => x.Id == order.Id).FirstOrDefault();
            oldOrder.PaidAmount = order.PaidAmount;
            oldOrder.BalanceAmount = order.BalanceAmount;

            _db.Orders.Update(oldOrder);
            _db.SaveChanges();
            return RedirectToAction("Index", "Order");

        }
        [HttpPost]
        public IActionResult Create(Order model)
        {
            User x = HttpContext.Session.GetObjectFromJson<User>("login");
            if (x == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var overlappingSlots = _db.Orders.Where(b => b.MarriageHallId == model.MarriageHallId && b.StartDate < model.EndDate && b.EndDate > model.StartDate).ToList();

            if (overlappingSlots.Any())
            {


                ViewBag.overlap = overlappingSlots;

                var futureSlots = _db.Orders.Where(b => b.StartDate > DateTime.Now).OrderBy(b => b.StartDate).ToList();
                ViewBag.futureSlots = futureSlots;

                ViewBag.services = _db.Servicesses.ToList();
                var marriageHalls = _db.MarriageHalls.ToList();
                ViewBag.MarriageHalls = new SelectList(marriageHalls, "Id", "Name");
                ViewBag.MarriageHall = marriageHalls;
                return View(model);
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
