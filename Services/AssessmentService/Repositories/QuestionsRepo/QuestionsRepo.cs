
using AssessmentService.Context;
using AssessmentService.Models;
using Microsoft.EntityFrameworkCore;

namespace AssessmentService.Repositories.QuestionsRepo
{
    public class QuestionsRepo : IQuestionsRepo
    {
        private readonly AssessmentContext _context;
        public QuestionsRepo(AssessmentContext context)
        {
            _context = context;
        }
        public async Task<Guid> CreateQuestion(QuestionModel model)
        {
            try
            {
                var question = await _context.Questions.AddAsync(model);
                await _context.SaveChangesAsync();
                return question.Entity.Id;
            }catch (Exception)
            {
                throw new Exception("Failed to create Question");
            }
        }

        public async Task<Guid> DeleteQuestion(Guid id)
        {
            try
            {
                var question = _context.Questions.Remove(await GetQuestionById(id));
                await _context.SaveChangesAsync();
                return question.Entity.Id;
            }catch (Exception)
            {
                throw new Exception("Failed to delete question");
            }
        }

        public async Task<QuestionModel> GetQuestionById(Guid id)
        {
            try
            {
                var question = await _context.Questions.FindAsync(id);
                return question;
            }catch (Exception)
            {
                throw new Exception("Failed to Fetch Question");
            }
        }

        public async Task<List<QuestionModel>> GetQuestions()
        {
            try
            {
                return await _context.Questions.ToListAsync();
            }catch (Exception)
            {
                throw new Exception("Failed to fetch Questions");
            }
        }

        public async Task<Guid> UpdateQuestion(QuestionModel model)
        {
            try
            {
                var question = _context.Questions.Update(model);
                await _context.SaveChangesAsync();
                return question.Entity.Id;
            }catch(Exception)
            {
                throw new Exception("Failed to Update Question");
            }
        }
    }
}
