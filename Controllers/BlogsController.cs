using Microsoft.AspNetCore.Mvc;

namespace BigonApp.UI.Controllers
{
    public class BlogsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details(int id = 5)
        {
            return View();
        }
    }
}
