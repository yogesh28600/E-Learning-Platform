namespace EnrollmentService.DTO;
public class EnrollmentDTO
{
    public Guid Id { get; set; }
    public Guid LearnerId { get; set; }  // Foreign key to User (Learner role)
    public Guid CourseId { get; set; }  // Foreign key to Course
    public DateTime EnrollmentDate { get; set; }
    public decimal AmountPaid { get; set; }
    public bool IsCompleted { get; set; }
}