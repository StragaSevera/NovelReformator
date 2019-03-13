using Microsoft.AspNetCore.Mvc;
using NovelReformatorClassLib.Models;
using NovelReformatorWebAPI.Services;
using NovelReformatorWebAPI.Services.Events;
using Prism.Events;

namespace NovelReformatorWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReformatController : Controller
    {
        private readonly IEventAggregator _aggregator;

        public ReformatController(IEventAggregator aggregator)
        {
            _aggregator = aggregator;
        }

        [HttpPost]
        public ApiResponse Index(ApiRequest apiRequest)
        {
            _aggregator.GetEvent<LogRequestEvent>().Publish(apiRequest);
            var apiResponse = new ApiResponse
            {
                Content = apiRequest.Type + ": " + apiRequest.Content,
                Success = apiRequest.Type != ReformatorType.FicBook
            };
            _aggregator.GetEvent<LogResponseEvent>().Publish(apiResponse);
            return apiResponse;
        }
    }
}