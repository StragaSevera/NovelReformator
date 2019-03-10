using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NovelReformatorClassLib.Models;
using NovelReformatorMVC.Models;
using NovelReformatorMVC.Services;

namespace NovelReformatorMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IReformatorService _reformator;

        public HomeController(IReformatorService reformator)
        {
            _reformator = reformator;
        }

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

        [HttpGet]
        public IActionResult Reformat()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Reformat(ApiRequest apiRequest)
        {
            if (!ModelState.IsValid) return View();
            try
            {
                ViewBag.Text = await _reformator.Reformat(apiRequest);
            }
            catch (Exception e)
            {
                ViewBag.Text = e.ToString();
            }

            return View(apiRequest);
        }
    }
}