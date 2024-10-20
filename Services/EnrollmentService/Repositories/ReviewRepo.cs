
using EnrollmentService.Context;
using EnrollmentService.Models;
using Microsoft.EntityFrameworkCore;

namespace EnrollmentService.Repositories.ReviewRepo
{
    public class ReviewRepo : IReviewRepo
    {
        private readonly EnrollmentDbContext _context;
        public ReviewRepo(EnrollmentDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> CreateReview(Review model)
        {
            try
            {
                var Review = await _context.Review.AddAsync(model);
                await _context.SaveChangesAsync();
                return Review.Entity.Id;
            }
            catch (Exception)
            {
                throw new Exception("Failed to create Review");
            }
        }

        public async Task<Guid> DeleteReview(Guid id)
        {
            try
            {
                var review = _context.Review.Remove(await GetReviewById(id));
                await _context.SaveChangesAsync();
                return review.Entity.Id;
            }
            catch (Exception)
            {
                throw new Exception("Failed to delete review");
            }
        }

        public async Task<Review> GetReviewById(Guid id)
        {
            try
            {
                var review = await _context.Review.FindAsync(id);
                return review;
            }
            catch (Exception)
            {
                throw new Exception("Failed to Fetch Review");
            }
        }

        public async Task<List<Review>> GetReview()
        {
            try
            {
                return await _context.Review.ToListAsync();
            }
            catch (Exception)
            {
                throw new Exception("Failed to fetch Review");
            }
        }

        public async Task<Guid> UpdateReview(Review model)
        {
            try
            {
                var Review = _context.Review.Update(model);
                await _context.SaveChangesAsync();
                return Review.Entity.Id;
            }
            catch (Exception)
            {
                throw new Exception("Failed to Update Review");
            }
        }
    }
}
