using System.ComponentModel.DataAnnotations;

namespace AssessmentService.DTO
{
    public class QuestionDTO
    {
        public Guid Id { get; set; }
        public string QuestionText { get; set; }
        public string AnswerOptions { get; set; }  // JSON or string for multiple choices
        public string CorrectAnswer { get; set; }
        public Guid QuizId { get; set; }  // Foreign key to Quiz
    }
}
