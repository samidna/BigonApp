using BigonApp.Models;
using BigonApp.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BigonApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ColorController : Controller
    {
        private readonly DataContext _db;

        public ColorController(DataContext db)
        {
            _db=db;
        }

        public IActionResult Index()
        {
            var colors = _db.Colors.ToList();
            return View(colors);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Color color)
        {
            color.CreatedAt=DateTime.Now;
            color.CreatedBy=1;
            _db.Colors.Add(color);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int id)
        {
            var color = _db.Colors.Find(id);
            if (color is null) return NotFound();
            return View(color);
        }
        [HttpPost]
        public IActionResult Update(Color color)
        {
            var dbColor = _db.Colors.Find(color.Id);
            if (dbColor is null) return NotFound();
            dbColor.Name=color.Name;
            dbColor.HexCode=color.HexCode;
            dbColor.ModifiedBy=1;
            dbColor.ModifiedAt=DateTime.Now;
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int id)
        {
            var color = _db.Colors.Find(id);
            if (color is null) return NotFound();
            return View(color);
        }
    }
}
