using System.ComponentModel.DataAnnotations;

namespace EnrollmentService.Models
{
    public class Enrollment
    {
        public Guid Id { get; set; }
        [Required]
        public Guid LearnerId { get; set; }  // Foreign key to User (Learner role)
        [Required]
        public Guid CourseId { get; set; }  // Foreign key to Course
        [Required]
        public DateTime EnrollmentDate { get; set; }
        public decimal AmountPaid { get; set; }
        [Required]
        public bool IsCompleted { get; set; }
    }
}