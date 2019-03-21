using System;
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

        //TODO: Fix problem with empty required fields
        [HttpPost]
        public async Task<int> Create(LogEntry entry)
        {
            try
            {
                _repository.Add(entry);
                await _repository.SaveAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }

            return entry.ID;
        }

        //TODO: Fix problem with empty required fields and forceful ID adding
        [HttpPut("{id}")]
        public async Task<int> Update(int id, LogEntry entry)
        {
            try
            {
                entry.ID = id;
                await _repository.Update(id, entry);
                await _repository.SaveAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }

            return id;
        }
        
        [HttpDelete("{id}")]
        public async Task<int> Delete(int id)
        {
            try
            {
                await _repository.Remove(id);
                await _repository.SaveAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }

            return id;
        }
    }
}