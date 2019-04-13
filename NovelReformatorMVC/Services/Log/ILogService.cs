using System.Collections.Generic;
using System.Threading.Tasks;
using NovelReformatorClassLib.Models;

namespace NovelReformatorMVC.Services.Log
{
    public interface ILogService
    {
        Task<IReadOnlyList<LogEntry>> GetAllAsync();
        Task<LogEntry> GetByIDAsync(int id);
        Task<bool> EditByIDAsync(int id, LogEntry logEntry);
        Task<bool> DeleteByIDAsync(int id);
    }
}