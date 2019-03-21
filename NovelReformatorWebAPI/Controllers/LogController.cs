using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NovelReformatorClassLib.Models;
using NovelReformatorWebAPI.Repositories;

namespace NovelReformatorWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : Controller
    {
        private readonly IGenericRepository<LogEntry> _repository;

        public LogController(IGenericRepository<LogEntry> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public Task<IReadOnlyList<LogEntry>> ReadAll()
        {
            return _repository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public Task<LogEntry> Read(int id)
        {
            return _repository.GetByIdAsync(id);
        }
    }
}