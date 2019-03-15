using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using NovelReformatorClassLib.Models;
using NovelReformatorWebAPI.Data;
using NovelReformatorWebAPI.Models;
using Prism.Events;

namespace NovelReformatorWebAPI.Services
{
    public class DbLogger : LoggerService
    {
        private readonly ReformatorContext _context;

        public DbLogger(IEventAggregator aggregator, IHttpContextAccessor httpContextAccessor,
            ReformatorContext context) : base(aggregator, httpContextAccessor)
        {
            _context = context;
        }

        protected override void LogRequest(ApiRequest request)
        {
            _context.LogEntries.Add(new LogEntry
            {
                Type = LogEntryType.Request,
                CreatedAt = DateTime.Now,
                IP = GetIp(),
                Content = request.ToString()
            });
            _context.SaveChanges();
        }

        protected override void LogResponse(ApiResponse response)
        {
            _context.LogEntries.Add(new LogEntry
            {
                Type = LogEntryType.Response,
                CreatedAt = DateTime.Now,
                IP = GetIp(),
                Content = response.ToString()
            });
            _context.SaveChanges();
        }
    }
}