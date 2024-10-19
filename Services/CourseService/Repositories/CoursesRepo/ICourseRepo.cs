using CourseService.Models;

namespace CourseService.Repositories.CoursesRepo
{
    public interface ICourseRepo
    {
        public Task<List<CourseModel>> GetCoursesAsync();
        public Task<Guid> UpdateCourseAsync(CourseModel course);
        public Task<Guid> DeleteCourseAsync(Guid id);
        public Task<CourseModel> GetCourseAsync(Guid id);
        public Task<Guid> CreateCourseAsync(CourseModel course);
    }
}
