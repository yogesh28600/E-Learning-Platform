using System.ComponentModel.DataAnnotations;

namespace AssessmentService.DTO
{
    public class QuizDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid CourseId { get; set; }
    }
}
