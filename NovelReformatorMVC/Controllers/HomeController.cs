using Microsoft.AspNetCore.Mvc;
using NovelReformatorMVC.Models;

namespace NovelReformatorMVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Novel novel)
        {
            if (!ModelState.IsValid) return View();
            novel.Content = "Reformatted content: \n" + novel.Content;
            return View(novel);
        }
    }
}