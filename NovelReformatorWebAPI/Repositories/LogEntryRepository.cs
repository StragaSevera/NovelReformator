using System.Threading.Tasks;
using NovelReformatorWebAPI.Data;
using NovelReformatorWebAPI.Models;

namespace NovelReformatorWebAPI.Repositories
{
    public class LogEntryRepository : GenericRepository<LogEntry, ReformatorContext>
    {
        public LogEntryRepository(ReformatorContext context) : base(context)
        {
        }
    }
}