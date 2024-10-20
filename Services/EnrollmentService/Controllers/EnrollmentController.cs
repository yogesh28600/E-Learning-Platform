using EnrollmentService.DTO;
using EnrollmentService.Models;
using EnrollmentService.Repositories.EnrollmentRepo;
using EnrollmentService.Repositories.ProgressRepo;
using EnrollmentService.Repositories.ReviewRepo;
using Microsoft.AspNetCore.Mvc;

namespace EnrollmentService.Controllers
{
    [Route("enrollment-service/[controller]/[action]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentRepo _enrollmentRepo;
        private readonly IProgressRepo _progressRepo;
        private readonly IReviewRepo _reviewRepo;
        public EnrollmentController(IEnrollmentRepo enrollmentRepo, IProgressRepo progressRepo, IReviewRepo reviewRepo)
        {
            _enrollmentRepo = enrollmentRepo;
            _progressRepo = progressRepo;
            _reviewRepo = reviewRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetEnrollment()
        {
            var enrollment = await _enrollmentRepo.GetEnrollment();
            return Ok(enrollment);
        }
        [HttpGet]
        public async Task<IActionResult> GetEnrollmentById(Guid id)
        {
            var enrollment = await _enrollmentRepo.GetEnrollmentById(id);
            if (enrollment == null)
                return NotFound();
            return Ok(enrollment);
        }
        [HttpPost]
        public async Task<IActionResult> CreateEnrollment(EnrollmentDTO model)
        {
            if (model.LearnerId == null || model.CourseId == null || model.AmountPaid == null || model.IsCompleted == null)
                return BadRequest("Invalid Data");
            Enrollment enrollment = new Enrollment()
            {
                LearnerId = model.LearnerId,
                CourseId = model.CourseId,
                AmountPaid = model.AmountPaid,
                IsCompleted = model.IsCompleted,
            };
            var Enrollment = await _enrollmentRepo.CreateEnrollment(enrollment);
            return CreatedAtAction(nameof(CreateEnrollment), enrollment);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEnrollment(EnrollmentDTO model)
        {
            if (model.Id == Guid.Empty)
                return BadRequest("Invalid Data");
            Enrollment enrollment = await _enrollmentRepo.GetEnrollmentById(model.Id);
            if (enrollment == null)
                return NotFound();
            enrollment.LearnerId = model.LearnerId;
            enrollment.CourseId = model.CourseId;
            enrollment.AmountPaid = model.AmountPaid! >1?model.AmountPaid:enrollment.AmountPaid;
            var question = await _enrollmentRepo.UpdateEnrollment(enrollment);
            return Ok(enrollment);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteEnrollment(Guid id)
        {
            var enrollment = await _enrollmentRepo.DeleteEnrollment(id);
            if (enrollment == Guid.Empty)
                return BadRequest("Invalid Data");
            return Ok(enrollment);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProgress()
        {
            var progress = await _progressRepo.GetProgress();
            return Ok(progress);
        }
        [HttpGet]
        public async Task<IActionResult> GetProgressById(Guid id)
        {
            var progress = await _progressRepo.GetProgressById(id);
            if (progress == null)
                return NotFound();
            return Ok(progress);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProgress(ProgressDTO model)
        {
            if (model.LearnerId == null || model.CourseId == Guid.Empty)
                return BadRequest("Invalid Data");
            Progress progress = new Progress()
            {
                LearnerId = model.LearnerId,
                CourseId = model.CourseId,
            };
            var Progress = await _progressRepo.CreateProgress(progress);
            return CreatedAtAction(nameof(CreateProgress), Progress);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProgress(ProgressDTO model)
        {
            if (model.Id == Guid.Empty)
                return BadRequest("Invalid Data");
            Progress progress = await _progressRepo.GetProgressById(model.Id);
            if (progress == null)
                return NotFound();
            progress.LearnerId = model.LearnerId;
            var Progress = await _progressRepo.UpdateProgress(progress);
            return Ok(progress);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProgress(Guid id)
        {
            var progress = await _progressRepo.DeleteProgress(id);
            if (progress == Guid.Empty)
                return BadRequest("Invalid Data");
            return Ok(progress);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllReview()
        {
            var review = await _reviewRepo.GetReview();
            return Ok(review);
        }
        [HttpGet]
        public async Task<IActionResult> GetReviewById(Guid id)
        {
            var review = await _reviewRepo.GetReviewById(id);
            if (review == null)
                return NotFound();
            return Ok(review);
        }
        [HttpPost]
        public async Task<IActionResult> CreateReview(ReviewDTO model)
        {
            if (model.LearnerId == null || model.CourseId == Guid.Empty)
                return BadRequest("Invalid Data");
            Review review = new Review()
            {
                LearnerId = model.LearnerId,
                CourseId = model.CourseId,
            };
            var Review = await _reviewRepo.CreateReview(review);
            return CreatedAtAction(nameof(CreateReview), Review);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateReview(ReviewDTO model)
        {
            if (model.Id == Guid.Empty)
                return BadRequest("Invalid Data");
            Review review = await _reviewRepo.GetReviewById(model.Id);
            if (review == null)
                return NotFound();
            review.LearnerId = model.LearnerId;
            var Review = await _reviewRepo.UpdateReview(review);
            return Ok(review);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteReview(Guid id)
        {
            var review = await _reviewRepo.DeleteReview(id);
            if (review == Guid.Empty)
                return BadRequest("Invalid Data");
            return Ok(review);

        }
    }
}
