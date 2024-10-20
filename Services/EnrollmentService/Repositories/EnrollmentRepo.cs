
using EnrollmentService.Context;
using EnrollmentService.Models;
using Microsoft.EntityFrameworkCore;

namespace EnrollmentService.Repositories.EnrollmentRepo
{
    public class EnrollmentRepo : IEnrollmentRepo
    {
        private readonly EnrollmentDbContext _context;
        public EnrollmentRepo(EnrollmentDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> CreateEnrollment(Enrollment model)
        {
            try
            {
                var Enrollment = await _context.Enrollment.AddAsync(model);
                await _context.SaveChangesAsync();
                return Enrollment.Entity.Id;
            }
            catch (Exception)
            {
                throw new Exception("Failed to create Enrollment");
            }
        }

        public async Task<Guid> DeleteEnrollment(Guid id)
        {
            try
            {
                var enrollment = _context.Enrollment.Remove(await GetEnrollmentById(id));
                await _context.SaveChangesAsync();
                return enrollment.Entity.Id;
            }
            catch (Exception)
            {
                throw new Exception("Failed to delete enrollment");
            }
        }

        public async Task<Enrollment> GetEnrollmentById(Guid id)
        {
            try
            {
                var enrollment = await _context.Enrollment.FindAsync(id);
                return enrollment;
            }
            catch (Exception)
            {
                throw new Exception("Failed to Fetch Enrollment");
            }
        }

        public async Task<List<Enrollment>> GetEnrollment()
        {
            try
            {
                return await _context.Enrollment.ToListAsync();
            }
            catch (Exception)
            {
                throw new Exception("Failed to fetch Enrollment");
            }
        }

        public async Task<Guid> UpdateEnrollment(Enrollment model)
        {
            try
            {
                var Enrollment = _context.Enrollment.Update(model);
                await _context.SaveChangesAsync();
                return Enrollment.Entity.Id;
            }
            catch (Exception)
            {
                throw new Exception("Failed to Update Enrollment");
            }
        }
    }
}
