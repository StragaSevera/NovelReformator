using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NovelReformatorClassLib.Models;
using NovelReformatorMVC.Models.ViewModels;
using NovelReformatorMVC.Services.Log;

namespace NovelReformatorMVC.Controllers
{
    public class LogController : Controller
    {
        private readonly ILogService _logService;

        public LogController(ILogService logService)
        {
            _logService = logService;
        }

        [HttpGet]
        public Task<IActionResult> Index(int? id)
        {
            return id is null ? ReadAll() : Read(id.Value);
        }

        private async Task<IActionResult> ReadAll()
        {
            IReadOnlyList<LogEntry> logEntries = new List<LogEntry>();
            try
            {
                logEntries = await _logService.GetAllAsync();
            }
            catch (Exception e)
            {
                ViewBag.Error = e.ToString();
            }

            return View("ReadAll", logEntries);
        }

        private async Task<IActionResult> Read(int id)
        {
            LogEntry logEntry = null;
            try
            {
                logEntry = await _logService.GetByIDAsync(id);
            }
            catch (Exception e)
            {
                ViewBag.Error = e.ToString();
            }

            return View("Read", logEntry);
        }
    }
}