using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using NovelReformatorClassLib.Models;
using Prism.Events;

namespace NovelReformatorWebAPI.Services
{
    public class DebugLogger : LoggerService
    {
        public DebugLogger(IEventAggregator aggregator, IHttpContextAccessor httpContextAccessor) : base(aggregator,
            httpContextAccessor)
        {
        }

        protected override void LogRequest(ApiRequest request)
        {
            Debug.WriteLine($"[{DateTime.Now}] {GetIp()}: {request}");
        }

        protected override void LogResponse(ApiResponse response)
        {
            Debug.WriteLine($"[{DateTime.Now}] {GetIp()}: {response}");
        }
    }
}