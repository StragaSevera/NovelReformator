using System.Net.Http;
using System.Threading.Tasks;
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

        [HttpGet]
        public new IActionResult Request()
        {
            return View();
        }

        [HttpPost]
        // ReSharper почему-то считает этот new излишним, хотя без него выдается warning
        public new async Task<IActionResult> Request(ApiRequest apiRequest)
        {
            if (!ModelState.IsValid) return View();
            // По-хорошему, нужно сделать отдельный сервисный объект, а не дергать прямо отсюда HTTP
            using (var httpClient = new HttpClient())
            using (var request = new HttpRequestMessage(HttpMethod.Get,
                $"https://localhost:5003/api/home/{apiRequest.Content}"))
            using (var response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode(); // Вместо этого можно проверять статус вручную во View
                apiRequest.Content = await response.Content.ReadAsStringAsync();
                return View(apiRequest);
            }
        }
    }
}