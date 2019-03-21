using NovelReformatorClassLib.Models;
using NovelReformatorWebAPI.Data;

namespace NovelReformatorWebAPI.Repositories
{
    public class LogEntryRepository : GenericRepository<LogEntry, ReformatorContext>
    {
        public LogEntryRepository(ReformatorContext context) : base(context)
        {
        }
    }
}