using EnrollmentService.Models;
using Microsoft.EntityFrameworkCore;

namespace EnrollmentService.Context
{
    public class EnrollmentDbContext : DbContext
    {
        public EnrollmentDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Enrollment> Enrollment { get; set; }
        public DbSet<Progress> Progress { get; set; }
        public DbSet<Review> Review { get; set; }
    }
}
