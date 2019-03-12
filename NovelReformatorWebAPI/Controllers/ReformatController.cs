using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NovelReformatorClassLib.Models;
using NovelReformatorWebAPI.Services;

namespace NovelReformatorWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReformatController : Controller
    {
        private readonly LoggerService _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ReformatController(LoggerService logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        public ApiResponse Index(ApiRequest apiRequest)
        {
            _logger.LogRequest(apiRequest, _httpContextAccessor.HttpContext);
            var response = new ApiResponse
            {
                Content = apiRequest.Type + ": " + apiRequest.Content,
                Success = apiRequest.Type != ReformatorType.FicBook
            };
            _logger.LogResponse(response, _httpContextAccessor.HttpContext);
            return response;
        }
    }
}