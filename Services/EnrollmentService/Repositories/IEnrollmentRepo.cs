using EnrollmentService.Models;
namespace EnrollmentService.Repositories.EnrollmentRepo
{
    public interface IEnrollmentRepo
    {
        public Task<List<Enrollment>> GetEnrollment();
        public Task<Enrollment> GetEnrollmentById(Guid id);
        public Task<Guid> CreateEnrollment(Enrollment enrollment);
        public Task<Guid> UpdateEnrollment(Enrollment enrollment);
        public Task<Guid> DeleteEnrollment(Guid id);
    }
}
