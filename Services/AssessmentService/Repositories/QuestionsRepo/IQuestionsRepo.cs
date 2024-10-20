using AssessmentService.Models;

namespace AssessmentService.Repositories.QuestionsRepo
{
    public interface IQuestionsRepo
    {
        public Task<List<QuestionModel>> GetQuestions();
        public Task<QuestionModel> GetQuestionById(Guid id);
        public Task<Guid> CreateQuestion(QuestionModel question);
        public Task<Guid> UpdateQuestion(QuestionModel question);
        public Task<Guid> DeleteQuestion(Guid id);
    }
}
