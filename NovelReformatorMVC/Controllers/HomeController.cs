using Microsoft.AspNetCore.Mvc;

namespace NovelReformatorMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View(null, "world");
        }
    }
}