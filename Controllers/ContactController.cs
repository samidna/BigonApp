using Microsoft.AspNetCore.Mvc;

namespace BigonApp.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
