using Microsoft.EntityFrameworkCore;
using NovelReformatorWebAPI.Models;

namespace NovelReformatorWebAPI.Data
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class ReformatorContext : DbContext
    {
        public ReformatorContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<LogEntry> LogEntries { get; set; }
    }
}