
using EnrollmentService.Context;
using EnrollmentService.Models;
using Microsoft.EntityFrameworkCore;

namespace EnrollmentService.Repositories.ProgressRepo
{
    public class ProgressRepo : IProgressRepo
    {
        private readonly EnrollmentDbContext _context;
        public ProgressRepo(EnrollmentDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> CreateProgress(Progress model)
        {
            try
            {
                var Progress = await _context.Progress.AddAsync(model);
                await _context.SaveChangesAsync();
                return Progress.Entity.Id;
            }
            catch (Exception)
            {
                throw new Exception("Failed to create Progress");
            }
        }

        public async Task<Guid> DeleteProgress(Guid id)
        {
            try
            {
                var progress = _context.Progress.Remove(await GetProgressById(id));
                await _context.SaveChangesAsync();
                return progress.Entity.Id;
            }
            catch (Exception)
            {
                throw new Exception("Failed to delete progress");
            }
        }

        public async Task<Progress> GetProgressById(Guid id)
        {
            try
            {
                var progress = await _context.Progress.FindAsync(id);
                return progress;
            }
            catch (Exception)
            {
                throw new Exception("Failed to Fetch Progress");
            }
        }

        public async Task<List<Progress>> GetProgress()
        {
            try
            {
                return await _context.Progress.ToListAsync();
            }
            catch (Exception)
            {
                throw new Exception("Failed to fetch Progress");
            }
        }

        public async Task<Guid> UpdateProgress(Progress model)
        {
            try
            {
                var Progress = _context.Progress.Update(model);
                await _context.SaveChangesAsync();
                return Progress.Entity.Id;
            }
            catch (Exception)
            {
                throw new Exception("Failed to Update Progress");
            }
        }
    }
}
