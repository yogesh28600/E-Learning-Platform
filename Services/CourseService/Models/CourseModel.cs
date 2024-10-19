using System.ComponentModel.DataAnnotations;

namespace CourseService.Models
{
    public class CourseModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Guid TrainerId { get; set; }  // Foreign key to User (Trainer)
        [Required]
        public string Category { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<ModulesModel> Modules { get; set; } = new List<ModulesModel>();  // One-to-many relationship
    }
}
