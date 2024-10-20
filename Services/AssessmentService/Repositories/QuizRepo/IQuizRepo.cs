using AssessmentService.Models;

namespace AssessmentService.Repositories.QuizRepo
{
    public interface IQuizRepo
    {
        public Task<List<QuizModel>> GetQuiz();
        public Task<QuizModel> GetQuizById(Guid id);
        public Task<Guid> CreateQuiz(QuizModel quiz);
        public Task<Guid> UpdateQuiz(QuizModel quiz);
        public Task<Guid> DeleteQuiz(Guid id);
    }
}
