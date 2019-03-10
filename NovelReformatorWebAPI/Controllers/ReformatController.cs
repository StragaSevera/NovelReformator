using Microsoft.AspNetCore.Mvc;
using NovelReformatorClassLib.Models;

namespace NovelReformatorWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReformatController : Controller
    {
        [HttpPost]
        public string Index(ApiRequest apiRequest)
        {
            return apiRequest.Type + ": " + apiRequest.Content;
        }
    }
}