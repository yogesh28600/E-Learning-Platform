using CourseService.Models;

namespace CourseService.Repositories.ModulesRepo
{
    public interface IModulesRepo
    {
        public Task<List<ModulesModel>> GetModulesAsync();
        public Task<ModulesModel> GetModuleAsync(Guid id);
        public Task<Guid> CreateModuleAsync(ModulesModel model);
        public Task<Guid> UpdateModuleAsync(ModulesModel module);
        public Task<Guid> DeleteModuleAsync(Guid id);
    }
}
