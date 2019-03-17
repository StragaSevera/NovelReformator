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
        private readonly IRequestServiceFactory _serviceFactory;

        public ReformatController(IEventAggregator aggregator, IRequestServiceFactory serviceFactory)
        {
            _aggregator = aggregator;
            _serviceFactory = serviceFactory;
            _serviceFactory.InitializeRequestServices();
        }

        public new void Dispose()
        {
            base.Dispose();
            _serviceFactory.Dispose();
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