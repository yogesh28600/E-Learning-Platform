using EnrollmentService.Models;
namespace EnrollmentService.Repositories.ProgressRepo
{
    public interface IProgressRepo
    {
        public Task<List<Progress>> GetProgress();
        public Task<Progress> GetProgressById(Guid id);
        public Task<Guid> CreateProgress(Progress progress);
        public Task<Guid> UpdateProgress(Progress progress);
        public Task<Guid> DeleteProgress(Guid id);
    }
}
