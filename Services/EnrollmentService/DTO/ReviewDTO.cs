namespace EnrollmentService.DTO
{
    public class ReviewDTO
    {
        public Guid Id { get; set; }
        public Guid LearnerId { get; set; }  // Foreign key to User (Learner)
        public Guid CourseId { get; set; }  // Foreign key to Course
        public int Rating { get; set; }  // 1 to 5 rating
        public string Comment { get; set; }
    }
}
