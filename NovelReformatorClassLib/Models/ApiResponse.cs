using System.ComponentModel.DataAnnotations;

namespace NovelReformatorClassLib.Models
{
    public class ApiResponse
    {
        [Required]
        public string Content { get; set; }

        public bool Success { get; set; }

        public override string ToString()
        {
            return Success ? $"Successfully converted:\n{Content}" : "Conversion failed!";
        }
    }
}