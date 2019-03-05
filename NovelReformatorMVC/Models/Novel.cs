using System.ComponentModel.DataAnnotations;

namespace NovelReformatorMVC.Models
{
    public class Novel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Content { get; set; }
    }
}