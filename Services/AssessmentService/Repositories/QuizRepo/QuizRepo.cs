using AssessmentService.Context;
using AssessmentService.Models;
using Microsoft.EntityFrameworkCore;

namespace AssessmentService.Repositories.QuizRepo
{
    public class QuizRepo : IQuizRepo
    {
        private readonly AssessmentContext _context;
        public QuizRepo(AssessmentContext context)
        {
            _context = context;
        }
        public async Task<Guid> CreateQuiz(QuizModel model)
        {
            try
            {
                var quiz = await _context.Quiz.AddAsync(model);
                await _context.SaveChangesAsync();
                return quiz.Entity.Id;
            }catch (Exception)
            {
                throw new Exception("Failed to create Quiz");
            }
        }

        public async Task<Guid> DeleteQuiz(Guid id)
        {
            try
            {
                var quiz = _context.Quiz.Remove(await GetQuizById(id));
                await _context.SaveChangesAsync();
                return quiz.Entity.Id;
            }
            catch (Exception)
            {
                throw new Exception("Failed to delete Quiz");
            }
        }

        public async Task<List<QuizModel>> GetQuiz()
        {
            try
            {
                return await _context.Quiz.ToListAsync();
            }catch (Exception)
            {
                throw new Exception("Failed to fetch Quiz");
            }
        }

        public async Task<QuizModel> GetQuizById(Guid id)
        {
            try
            {
                return await _context.Quiz.FindAsync(id);
            }
            catch (Exception)
            {
                throw new Exception("Failed to fetch Quiz");
            }
        }

        public async Task<Guid> UpdateQuiz(QuizModel model)
        {
            try
            {
                var quiz = _context.Quiz.Update(model);
                await _context.SaveChangesAsync();
                return quiz.Entity.Id;
            }
            catch (Exception)
            {
                throw new Exception("Failed to update Quiz");
            }
        }
    }
}
