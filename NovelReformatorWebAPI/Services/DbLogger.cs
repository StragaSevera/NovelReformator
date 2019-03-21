using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NovelReformatorClassLib.Models;
using NovelReformatorWebAPI.Data;
using NovelReformatorWebAPI.Repositories;
using Prism.Events;

namespace NovelReformatorWebAPI.Services
{
    public class DbLogger : LoggerService
    {
        private readonly IServiceProvider _scopeFactory;

        public DbLogger(IEventAggregator aggregator, IHttpContextAccessor httpContextAccessor,
            IServiceProvider provider) : base(aggregator, httpContextAccessor)
        {
            _scopeFactory = provider;
        }

        protected override async void LogRequest(ApiRequest request)
        {
            await Log(LogEntryType.Request, request.ToString());
        }

        protected override async void LogResponse(ApiResponse response)
        {
            await Log(LogEntryType.Response, response.ToString());
        }

        private async Task Log(LogEntryType type, string content)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var repo = scope.ServiceProvider.GetService<IGenericRepository<LogEntry>>();
                repo.Add(new LogEntry
                {
                    Type = type,
                    CreatedAt = DateTime.Now,
                    IP = GetIp(),
                    Content = content
                });
                await repo.SaveAsync();
            }
        }
    }
}