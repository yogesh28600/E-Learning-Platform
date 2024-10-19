using CourseService.Context;
using CourseService.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseService.Repositories.ModulesRepo
{
    public class ModulesRepo : IModulesRepo
    {
        private readonly CourseContext _context;
        public ModulesRepo(CourseContext context)
        {
            _context = context;
        }
        public async Task<Guid> CreateModuleAsync(ModulesModel model)
        {
            try
            {
                var module = await _context.Modules.AddAsync(model);
                await _context.SaveChangesAsync();
                return module.Entity.Id;
                
            }catch (Exception)
            {
                throw new Exception("Failed to create Module");
            }
        }

        public async Task<Guid> DeleteModuleAsync(Guid id)
        {
            try
            {
                var module = _context.Modules.Remove(await GetModuleAsync(id));
                await _context.SaveChangesAsync();
                return module.Entity.Id;
            }catch(Exception)
            {
                throw new Exception("Failed to delete module");
            }
        }

        public async Task<ModulesModel> GetModuleAsync(Guid id)
        {
            try
            {
                var module = await _context.Modules.FindAsync(id);
                return module;
            }catch (Exception)
            {
                throw new Exception("Failed to Fetch module");
            }
        }

        public async Task<List<ModulesModel>> GetModulesAsync()
        {
            try
            {
                var modules = await _context.Modules.ToListAsync();
                return modules;
            }catch (Exception)
            {
                throw new Exception("Failed to fetch modules");
            }
        }

        public async Task<Guid> UpdateModuleAsync(ModulesModel model)
        {
            try
            {
                var module = _context.Modules.Update(model);
                await _context.SaveChangesAsync();
                return module.Entity.Id;
            }catch (Exception)
            {
                throw new Exception("Failed to update module");
            }
        }
    }
}
