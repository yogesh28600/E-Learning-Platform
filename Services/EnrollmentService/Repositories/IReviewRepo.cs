using EnrollmentService.Models;
namespace EnrollmentService.Repositories.ReviewRepo
{
    public interface IReviewRepo
    {
        public Task<List<Review>> GetReview();
        public Task<Review> GetReviewById(Guid id);
        public Task<Guid> CreateReview(Review review);
        public Task<Guid> UpdateReview(Review review);
        public Task<Guid> DeleteReview(Guid id);
    }
}
