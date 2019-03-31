using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NovelReformatorClassLib.Models;
using NovelReformatorMVC.Models.ViewModels;
using NovelReformatorMVC.Services;
using NovelReformatorMVC.Services.Reformator;

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
            return View(new RequestResponseComposite());
        }

        [HttpPost]
        public async Task<IActionResult> Index(ApiRequest apiRequest)
        {
            if (!ModelState.IsValid) return View();
            ApiResponse apiResponse = null;
            try
            {
                apiResponse = await _reformator.Reformat(apiRequest);
            }
            catch (Exception e)
            {
                ViewBag.Error = e.ToString();
            }

            return View(new RequestResponseComposite(apiRequest, apiResponse));
        }
    }
}