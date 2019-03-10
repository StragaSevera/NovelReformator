using System.ComponentModel.DataAnnotations;

namespace NovelReformatorClassLib.Models
{
    public class ApiRequest
    {
        [Required]
        public string Content { get; set; }
        [Required]
        public ReformatorType Type { get; set; }
    }
}