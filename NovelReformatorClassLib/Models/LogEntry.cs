using System;
using System.ComponentModel.DataAnnotations;

namespace NovelReformatorClassLib.Models
{
    public enum LogEntryType
    {
        Request,
        Response
    }

    public class LogEntry
    {
        public int ID { get; set; }

        [Required]
        public LogEntryType Type { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public string IP { get; set; }

        [Required]
        public string Content { get; set; }
    }
}