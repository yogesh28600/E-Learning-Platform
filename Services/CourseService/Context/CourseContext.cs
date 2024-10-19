using CourseService.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseService.Context
{
    public class CourseContext:DbContext
    {
        public CourseContext(DbContextOptions<CourseContext> options):base(options)
        {
            
        }
        public DbSet<CourseModel> Courses { get; set; }
        public DbSet<ModulesModel> Modules { get; set; }
    }
}
