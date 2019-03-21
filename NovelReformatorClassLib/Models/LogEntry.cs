using System;

namespace NovelReformatorClassLib.Models
{
    public enum LogEntryType
    {
        Request, Response
    }

    public class LogEntry
    {
        public int ID { get; set; }
        public LogEntryType Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public string IP { get; set; }
        public string Content { get; set; }
    }
}