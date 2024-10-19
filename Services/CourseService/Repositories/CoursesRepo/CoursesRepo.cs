using CourseService.Context;
using CourseService.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseService.Repositories.CoursesRepo
{
    public class CoursesRepo:ICourseRepo
    {
        private readonly CourseContext _context;
        public CoursesRepo(CourseContext context)
        {
            _context = context;
        }
        public async Task<List<CourseModel>> GetCoursesAsync()
        {
            try
            {
                var courses = await _context.Courses.ToListAsync<CourseModel>();
                return courses;
            }catch (Exception)
            {
                throw new Exception("Failed to fetch courses");
            }

        }
        public async Task<CourseModel> GetCourseAsync(Guid id)
        {
            try
            {
                var course = await _context.Courses.FindAsync(id);
                return course;
            }
            catch (Exception)
            {
                throw new Exception("Failed to fetch Course");
            }
        }
        public async Task<Guid> CreateCourseAsync(CourseModel model)
        {
            try
            {
                var course = await _context.Courses.AddAsync(model);
                await _context.SaveChangesAsync();
                return course.Entity.Id;
            }catch(Exception)
            {
                throw new Exception("Failed to create Course");
            }
        }
        public async Task<Guid> UpdateCourseAsync(CourseModel model)
        {
            try
            {
                var course = _context.Update(model);
                await _context.SaveChangesAsync();
                return course.Entity.Id;
            }catch(Exception)
            {
                throw new Exception("Failed to update course");
            }
        }
        public async Task<Guid> DeleteCourseAsync(Guid id)
        {
            try
            {
                var course = _context.Courses.Remove(await GetCourseAsync(id));
                await _context.SaveChangesAsync();
                return course.Entity.Id;
            }catch (Exception)
            {
                throw new Exception("Failed to delete course");
            }
        }
    }
}
