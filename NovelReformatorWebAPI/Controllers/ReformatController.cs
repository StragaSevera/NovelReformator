using Microsoft.AspNetCore.Mvc;
using NovelReformatorClassLib.Models;

namespace NovelReformatorWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReformatController : Controller
    {
        [HttpPost]
        public ApiResponse Index(ApiRequest apiRequest)
        {
            return new ApiResponse
            {
                Content = apiRequest.Type + ": " + apiRequest.Content,
                Success = apiRequest.Type != ReformatorType.FicBook
            };
        }
    }
}