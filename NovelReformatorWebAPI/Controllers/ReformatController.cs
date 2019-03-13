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

        public ReformatController(LoggerService logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ApiResponse Index(ApiRequest apiRequest)
        {
            _logger.LogRequest(apiRequest);
            var response = new ApiResponse
            {
                Content = apiRequest.Type + ": " + apiRequest.Content,
                Success = apiRequest.Type != ReformatorType.FicBook
            };
            _logger.LogResponse(response);
            return response;
        }
    }
}