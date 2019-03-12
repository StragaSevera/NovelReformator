using Microsoft.AspNetCore.Http;
using NovelReformatorClassLib.Models;

namespace NovelReformatorWebAPI.Services
{
    public abstract class LoggerService
    {
        public abstract void LogRequest(ApiRequest request, HttpContext context);
        public abstract void LogResponse(ApiResponse response, HttpContext context);

        protected static string GetIp(HttpContext context)
        {
            var ip = context.Connection.RemoteIpAddress.ToString();
            return ip == "::1" ? "127.0.0.1" : ip;
        }
    }
}