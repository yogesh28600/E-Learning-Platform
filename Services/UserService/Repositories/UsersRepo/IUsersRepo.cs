using UserService.Models;

namespace UserService.Repositories.UsersRepo
{
    public interface IUsersRepo
    {
        public Task<List<UserModel>> GetUsersAsync();
        public Task<UserModel> GetUserByIdAsync(Guid id);
        public Task<Guid> CreateUserAsync(UserModel user);
        public Task<Guid> UpdateUserAsync(UserModel user);
        public Task<Guid> DeleteUserAsync(Guid id);
    }
}
