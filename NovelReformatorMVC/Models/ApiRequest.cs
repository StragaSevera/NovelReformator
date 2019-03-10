using System.ComponentModel.DataAnnotations;

namespace NovelReformatorMVC.Models
{
    public class ApiRequest
    {
        [Required]
        public string Content { get; set; }
    }
}