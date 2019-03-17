using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NovelReformatorClassLib.Models;
using NovelReformatorWebAPI.Data;
using NovelReformatorWebAPI.Models;
using Prism.Events;

namespace NovelReformatorWebAPI.Services
{
    public class DbLogger : LoggerService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public DbLogger(IEventAggregator aggregator, IHttpContextAccessor httpContextAccessor,
            IServiceScopeFactory scopeFactory) : base(aggregator, httpContextAccessor)
        {
            _scopeFactory = scopeFactory;
        }

        protected override void LogRequest(ApiRequest request)
        {
            Log(LogEntryType.Request, request.ToString());
        }

        protected override void LogResponse(ApiResponse response)
        {
            Log(LogEntryType.Response, response.ToString());
        }

        private void Log(LogEntryType type, string content)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<ReformatorContext>();
                context.LogEntries.Add(new LogEntry
                {
                    Type = type,
                    CreatedAt = DateTime.Now,
                    IP = GetIp(),
                    Content = content
                });
                context.SaveChanges();
            }
        }
    }
}