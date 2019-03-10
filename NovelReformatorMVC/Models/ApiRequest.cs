using System.ComponentModel.DataAnnotations;
using NovelReformatorClassLib;

namespace NovelReformatorMVC.Models
{
    public class ApiRequest
    {
        [Required]
        public string Content { get; set; }
        [Required]
        public ReformatorType Type { get; set; }
    }
}