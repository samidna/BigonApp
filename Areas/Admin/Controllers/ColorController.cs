using BigonApp.Infrastructure.Entities;
using BigonApp.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BigonApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ColorController : Controller
    {
        private readonly IColorRepository _colorRepository;

        public ColorController(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        public IActionResult Index()
        {
            var colors = _colorRepository.GetAll(c => c.DeletedBy == null);
            return View(colors);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Color color)
        {
            _colorRepository.Add(color);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int id)
        {
            var color = _colorRepository.Get(c => c.Id == id);
            if (color is null) return NotFound();
            return View(color);
        }
        [HttpPost]
        public IActionResult Update(Color color)
        {
            //var dbColor = _db.Colors.Find(color.Id);
            //if (dbColor is null) return NotFound();
            //dbColor.Name=color.Name;
            //dbColor.HexCode=color.HexCode;
            //_db.SaveChanges();
            _colorRepository.Update(color);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int id)
        {
            var color = _colorRepository.Get(c => c.Id == id);
            if (color is null) return NotFound();
            return View(color);
        }
        public IActionResult Delete(int id)
        {
            //var color = _db.Colors.Find(id);
            //if (color is null) return Json(new
            //{
            //    error = true,
            //    message = "Color not found"
            //});

            //_db.Colors.Remove(color);
            //_db.SaveChanges();
            var color = _colorRepository.Get(c => c.Id == id);
            _colorRepository.Remove(color);
            var colors = _colorRepository.GetAll(c => c.DeletedBy == null);
            return PartialView("_Body", colors);
        }
    }
}
