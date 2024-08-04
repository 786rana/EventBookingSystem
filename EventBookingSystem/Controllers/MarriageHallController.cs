using EventBookingSystem.Common;
using EventBookingSystem.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventBookingSystem.Controllers
{
    public class MarriageHallController : Controller
    {
        private readonly EventBookingSystemOrg10Context _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MarriageHallController(EventBookingSystemOrg10Context db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            User user = HttpContext.Session.GetObjectFromJson<User>("login");
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (user.Email == "admin@gmail.com")
            {
                List<MarriageHall> x = _db.MarriageHalls.ToList();
                ViewBag.MarriageHall = x;
                return View(x);
            }
            else
            {
                List<MarriageHall> x = _db.MarriageHalls.Where(x => x.UserId == user.Id).ToList();
                ViewBag.MarriageHall = x;
                return View(x);
            }
        }
        public IActionResult Marriage()
        {
            User x = HttpContext.Session.GetObjectFromJson<User>("login");

            if (x == null)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.services = _db.Servicesses.ToList();
            var hall = _db.MarriageHalls.ToList();
            ViewBag.MarriageHall = hall;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Save(MarriageHall h, IFormFile imageFile)
        {
            User x = HttpContext.Session.GetObjectFromJson<User>("login");
            if (x == null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (imageFile != null && imageFile.Length > 0)
            {
                // Generate a unique filename for the image
                var fileName = Path.GetFileNameWithoutExtension(imageFile.FileName);
                var extension = Path.GetExtension(imageFile.FileName);
                var uniqueFileName = $"{fileName}_{DateTime.Now.Ticks}{extension}";

                // Set the path to the wwwroot/images folder
                var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "MarriageImages");

                // Ensure the directory exists
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
                var filePath = Path.Combine(uploadPath, uniqueFileName);

                // Save the image file to the specified path
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(fileStream);
                }

                // Save the image URL to the database (assuming a column named ImageUrl in your database table)
                h.ImageUrl = $"/MarriageImages/{uniqueFileName}";
            }



            if (h.Id > 0)
            {
                _db.MarriageHalls.Update(h);
            }
            else
            {
                h.UserId = x.Id;
                _db.MarriageHalls.Add(h);
                _db.SaveChanges();
            }

            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            ViewBag.services = _db.Servicesses.ToList();
            MarriageHall x = _db.MarriageHalls.Include(x => x.MarriageHallServices).Where(x => x.Id == id).FirstOrDefault();

            var hall = _db.MarriageHalls.ToList();
            ViewBag.MarriageHall = hall;
            return View("Marriage", x);
        }

        public IActionResult Detail(int id)
        {
            ViewBag.services = _db.Servicesses.ToList();
            MarriageHall x = _db.MarriageHalls.Include(x => x.MarriageHallServices).ThenInclude(y => y.Service).Where(x => x.Id == id).FirstOrDefault();
            var hall = _db.MarriageHalls.ToList();
            ViewBag.MarriageHall = hall;
            return View(x);
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
