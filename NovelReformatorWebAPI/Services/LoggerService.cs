using Microsoft.AspNetCore.Http;
using NovelReformatorClassLib.Models;
using NovelReformatorWebAPI.Services.Events;
using Prism.Events;

namespace NovelReformatorWebAPI.Services
{
    public abstract class LoggerService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private HttpContext HttpContext => _httpContextAccessor.HttpContext;

        protected LoggerService(IEventAggregator aggregator, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

            aggregator.GetEvent<LogRequestEvent>().Subscribe(LogRequest);
            aggregator.GetEvent<LogResponseEvent>().Subscribe(LogResponse);
        }

        protected abstract void LogRequest(ApiRequest request);
        protected abstract void LogResponse(ApiResponse response);

        protected string GetIp()
        {
            var ip = HttpContext.Connection.RemoteIpAddress.ToString();
            return ip == "::1" ? "127.0.0.1" : ip;
        }
    }
}