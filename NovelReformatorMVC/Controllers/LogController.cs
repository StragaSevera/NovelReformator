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
        public async Task<IActionResult> Index()
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

            return View(logEntries);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Index([FromQuery] int id)
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

            return View("IndexID", logEntry);
        }
    }
}