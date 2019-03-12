using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using NovelReformatorClassLib.Models;

namespace NovelReformatorWebAPI.Services
{
    public class DebugLogger : LoggerService
    {
        public override void LogRequest(ApiRequest request, HttpContext context)
        {
            Debug.WriteLine($"[{DateTime.Now}] {GetIp(context)}: {request}");
        }

        public override void LogResponse(ApiResponse response, HttpContext context)
        {
            Debug.WriteLine($"[{DateTime.Now}] {GetIp(context)}: {response}");
        }
    }
}