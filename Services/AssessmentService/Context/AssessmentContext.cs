using AssessmentService.Models;
using Microsoft.EntityFrameworkCore;

namespace AssessmentService.Context
{
    public class AssessmentContext : DbContext
    {
        public AssessmentContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<QuestionModel> Questions { get; set; }
        public DbSet<QuizModel> Quiz { get; set; }
    }
}
