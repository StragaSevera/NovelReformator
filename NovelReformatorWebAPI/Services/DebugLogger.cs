using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using NovelReformatorClassLib.Models;

namespace NovelReformatorWebAPI.Services
{
    public class DebugLogger : LoggerService
    {
        public DebugLogger(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }

        public override void LogRequest(ApiRequest request)
        {
            Debug.WriteLine($"[{DateTime.Now}] {GetIp()}: {request}");
        }

        public override void LogResponse(ApiResponse response)
        {
            Debug.WriteLine($"[{DateTime.Now}] {GetIp()}: {response}");
        }
    }
}