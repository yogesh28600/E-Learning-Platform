using Microsoft.EntityFrameworkCore;
using UserService.Context;
using UserService.Models;

namespace UserService.Repositories.UsersRepo
{
    public class UsersRepo : IUsersRepo
    {
        private readonly UserContext _context;
        public UsersRepo(UserContext context)
        {
            _context = context;
        }
        public async Task<Guid> CreateUserAsync(UserModel model)
        {
            try
            {
                var user = await _context.Users.AddAsync(model);
                await _context.SaveChangesAsync();
                return user.Entity.Id;

            }catch (Exception)
            {
                throw new Exception("Failed to create user");
            }
        }

        public async Task<Guid> DeleteUserAsync(Guid id)
        {
            try
            {
                var user = _context.Users.Remove(await GetUserByIdAsync(id));
                await _context.SaveChangesAsync();
                return user.Entity.Id;
            }catch(Exception)
            {
                throw new Exception("Failed to delete User");
            }
        }

        public async Task<UserModel> GetUserByIdAsync(Guid id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                return user;
            }catch(Exception)
            {
                throw new Exception("Failed to fetch user");
            }
        }

        public async Task<List<UserModel>> GetUsersAsync()
        {
            try
            {
                var users = await _context.Users.ToListAsync<UserModel>();
                return users;
            }catch(Exception)
            {
                throw new Exception("Failed to fetch users");
            }
        }

        public async Task<Guid> UpdateUserAsync(UserModel model)
        {
            try
            {
                 var user = _context.Users.Update(model);
                 await _context.SaveChangesAsync();
                return user.Entity.Id;
            }catch (Exception)
            {
                throw new Exception("Failed to Update User");
            }
        }
    }
}
