using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NovelReformatorClassLib;
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
            ViewBag.Text = await _reformator.Reformat(apiRequest.Content, apiRequest.Type);
            return View(apiRequest);

            // По-хорошему, нужно сделать отдельный сервисный объект, а не дергать прямо отсюда HTTP
//            using (var httpClient = new HttpClient())
//            using (var request = new HttpRequestMessage(HttpMethod.Get,
//                $"https://localhost:5003/api/home/{apiRequest.Content}"))
//            using (var response = await httpClient.SendAsync(request))
//            {
//                response.EnsureSuccessStatusCode(); // Вместо этого можно проверять статус вручную во View
//                apiRequest.Content = await response.Content.ReadAsStringAsync();
//                return View(apiRequest);
//            }
        }
    }
}