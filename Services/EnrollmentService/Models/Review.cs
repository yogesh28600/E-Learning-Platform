using System.ComponentModel.DataAnnotations;

namespace EnrollmentService.Models
{
    public class Review
    {
        public Guid Id { get; set; }
        [Required]
        public Guid LearnerId { get; set; }  // Foreign key to User (Learner)
        [Required]
        public Guid CourseId { get; set; }  // Foreign key to Course
        [Required]
        public int Rating { get; set; }  // 1 to 5 rating
        [Required]
        public string Comment { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
    }
}