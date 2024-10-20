namespace EnrollmentService.DTO
{
    public class ProgressDTO
    {
        public Guid Id { get; set; }
        public Guid LearnerId { get; set; }  // Foreign key to User (Learner)
        public Guid CourseId { get; set; }  // Foreign key to Course
        public Guid ModuleId { get; set; }  // Foreign key to Module
        public bool IsCompleted { get; set; }
    }
}
