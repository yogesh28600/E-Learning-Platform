using System.ComponentModel.DataAnnotations;

namespace AssessmentService.Models
{
    public class QuizModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public Guid CourseId { get; set; }  // Foreign key to Course
        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<QuestionModel> Questions { get; set; } = new List<QuestionModel>();  // One-to-many relationship
    }
}
