using CourseService.DTO;
using CourseService.Models;
using CourseService.Repositories.CoursesRepo;
using CourseService.Repositories.ModulesRepo;
using Microsoft.AspNetCore.Mvc;

namespace CourseService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepo _courseRepo;
        private readonly IModulesRepo _modulesRepo;
        public CourseController(ICourseRepo courseRepo, IModulesRepo modulesRepo)
        {
            _courseRepo = courseRepo;
            _modulesRepo = modulesRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _courseRepo.GetCoursesAsync();
            return Ok(courses);
        }
        [HttpGet]
        public async Task<IActionResult> GetCourseById(Guid id)
        {
            var course = await _courseRepo.GetCourseAsync(id);
            if (course == null)
                return NotFound();
            return Ok(course);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCourse(CourseDTO model)
        {
            if (model.Title.Length < 1 || model.Price < 0 || model.TrainerId == Guid.Empty || model.Category.Length < 1 || model.Description.Length < 10)
                return BadRequest();
            CourseModel courseModel = new CourseModel()
            {
                Title = model.Title,
                Description = model.Description,
                TrainerId = model.TrainerId,
                Category = model.Category,
                Price = model.Price,
                CreatedAt = DateTime.UtcNow
            };
            var course = await _courseRepo.CreateCourseAsync(courseModel);
            if (course == Guid.Empty)
                return BadRequest();
            return CreatedAtAction(nameof(CreateCourse),course);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCourse(CourseDTO model)
        {
            if (model == null || model.Id == Guid.Empty)
                return BadRequest("Invalid course data.");

            var courseModel = await _courseRepo.GetCourseAsync(model.Id);
            if (courseModel == null)
                return NotFound();

            courseModel.Title = model.Title ?? courseModel.Title;
            courseModel.Description = model.Description ?? courseModel.Description;
            courseModel.Category = model.Category ?? courseModel.Category;
            courseModel.Price = model.Price !>1 ? model.Price : courseModel.Price;
            courseModel.UpdatedAt = DateTime.Now;

            var updatedCourseId = await _courseRepo.UpdateCourseAsync(courseModel);
            if (updatedCourseId == Guid.Empty)
                return BadRequest("Failed to update course.");

            return Ok(courseModel); // or return updatedCourseId if you prefer
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCourse(Guid id)
        {
            var course = await _courseRepo.DeleteCourseAsync(id);
            if(course == Guid.Empty)
                return BadRequest();
            return Ok(course);
        }
        [HttpGet]
        public async Task<IActionResult> GetModules()
        {
            var modules = await _modulesRepo.GetModulesAsync();
            return Ok(modules);
        }
        [HttpGet]
        public async Task<IActionResult> GetModule(Guid id)
        {
            var module = await _modulesRepo.GetModuleAsync(id);
            if (module == null)
                return BadRequest();
            return Ok(module);
        }
        [HttpPost]
        public async Task<IActionResult> CreateModule(ModuleDTO model)
        {
            if (model.Title.Length < 1 || model.CourseId == Guid.Empty || model.VideoUrl.Length < 1)
                return BadRequest();
            ModulesModel modulesModel = new ModulesModel()
            {
                Title = model.Title,
                VideoUrl = model.VideoUrl,
                CourseId = model.CourseId,
                AdditionalResources = model.AdditionalResources,
                CreatedAt = DateTime.UtcNow
            };
            var module = await _modulesRepo.CreateModuleAsync(modulesModel);
            if(module == Guid.Empty)
                return BadRequest();
            return CreatedAtAction(nameof(CreateModule), module);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMoulue(ModuleDTO model)
        {
            if (model.Id == Guid.Empty)
                return BadRequest();
            ModulesModel modulesModel = await _modulesRepo.GetModuleAsync(model.Id);
            modulesModel.Title = model.Title ?? modulesModel.Title;
            modulesModel.VideoUrl = model.VideoUrl ?? modulesModel.VideoUrl;
            modulesModel.AdditionalResources = model.AdditionalResources ?? modulesModel.AdditionalResources;
            modulesModel.UpdatedAt = DateTime.UtcNow;
            var module = await _modulesRepo.UpdateModuleAsync(modulesModel);
            if(module == Guid.Empty)
                return BadRequest();
            return Ok(module);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteModule(Guid id)
        {
            var module = await _modulesRepo.DeleteModuleAsync(id);
            if (module == Guid.Empty)
                return BadRequest();
            return Ok(module);
        }


    }
}
