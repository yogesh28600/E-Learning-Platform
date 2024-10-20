using System.ComponentModel.DataAnnotations;

namespace EnrollmentService.Models
{
    public class Progress
    {
        public Guid Id { get; set; }
        [Required]
        public Guid LearnerId { get; set; }  // Foreign key to User (Learner)
        [Required]
        public Guid CourseId { get; set; }  // Foreign key to Course
        [Required]
        public Guid ModuleId { get; set; }  // Foreign key to Module
        [Required]
        public bool IsCompleted { get; set; }
        public DateTime LastWatchedAt { get; set; }
    }
}