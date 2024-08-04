using EventBookingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventBookingSystem.Controllers
{
    public class ServicesController : Controller
    {
        private readonly EventBookingSystemOrg10Context _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ServicesController(EventBookingSystemOrg10Context db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Servicess> x = _db.Servicesses.ToList();
            var hall = _db.MarriageHalls.ToList();
            ViewBag.MarriageHall = hall;
            return View(x);
        }
        public IActionResult Create()
        {
            var hall = _db.MarriageHalls.ToList();
            ViewBag.MarriageHall = hall;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Save(Servicess x, IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                // Generate a unique filename for the image
                var fileName = Path.GetFileNameWithoutExtension(imageFile.FileName);
                var extension = Path.GetExtension(imageFile.FileName);
                var uniqueFileName = $"{fileName}_{DateTime.Now.Ticks}{extension}";

                // Set the path to the wwwroot/images folder
                var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "serviceImages");

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
                x.ImageUrl = $"/serviceImages/{uniqueFileName}";
            }

            if (x.Id > 0)
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
            var hall = _db.MarriageHalls.ToList();
            ViewBag.MarriageHall = hall;
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

        public JsonResult GetByMarriageHall(int id)
        {
            var result = _db.MarriageHallServices.Include(inc => inc.Service).Where(x => x.MarriageHallId == id).Select(x => new { id = x.ServiceId, name = x.Service.Name, price = x.Price }).ToList();
            return Json(new { result });
        }
    }
}
