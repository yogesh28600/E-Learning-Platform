using System.ComponentModel.DataAnnotations;

namespace AssessmentService.Models
{
    public class QuestionModel
    {
        public Guid Id { get; set; }
        [Required]
        public string QuestionText { get; set; }
        [Required]
        public string AnswerOptions { get; set; }  // JSON or string for multiple choices
        [Required]
        public string CorrectAnswer { get; set; }
        [Required]
        public Guid QuizId { get; set; }  // Foreign key to Quiz
        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
