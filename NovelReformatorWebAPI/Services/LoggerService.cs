using Microsoft.AspNetCore.Http;
using NovelReformatorClassLib.Models;

namespace NovelReformatorWebAPI.Services
{
    public abstract class LoggerService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        protected HttpContext HttpContext => _httpContextAccessor.HttpContext;

        protected LoggerService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public abstract void LogRequest(ApiRequest request);
        public abstract void LogResponse(ApiResponse response);

        protected string GetIp()
        {
            var ip = HttpContext.Connection.RemoteIpAddress.ToString();
            return ip == "::1" ? "127.0.0.1" : ip;
        }
    }
}