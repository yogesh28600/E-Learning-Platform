using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseService.Models
{
    public class ModulesModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string VideoUrl { get; set; }  // For storing the video link
        [Required]
        public string AdditionalResources { get; set; }  // Links to PDFs, other files
        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        [Required]
        public Guid CourseId { get; set; }
        [ForeignKey("CourseId")]
        public CourseModel Course { get; set; }  // Foreign key to Course
    }
}
