using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.DTO;
using UserService.Models;
using UserService.Repositories.UsersRepo;

namespace UserService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsersRepo _repo;
        public UserController(IUsersRepo repo)
        {
            _repo = repo; 
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repo.GetUsersAsync();
            return Ok(users);
        }
        [HttpGet]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var user = await _repo.GetUserByIdAsync(id);
            if(user == null)
                return NotFound();
            return Ok(user);

        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDTO model)
        {
            if (model.FirstName == null || model.LastName == null || model.Email == null || model.PasswordHash == null || model.Role == null)
                return BadRequest("Invalid Data");
            UserModel userModel = new UserModel()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PasswordHash = model.PasswordHash,
                Role = model.Role,
                CreatedAt = DateTime.UtcNow
            };
            var user = await _repo.CreateUserAsync(userModel);
            if (user == Guid.Empty)
                return BadRequest("Something went wrong try again");
            return CreatedAtAction(nameof(CreateUser), user);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserDTO model)
        {
            if (model.Id == Guid.Empty)
                return BadRequest("Invalid Data");
            UserModel userModel = await _repo.GetUserByIdAsync(model.Id);
            if (userModel == null)
                return NotFound();
            userModel.FirstName = model.FirstName ?? userModel.FirstName;
            userModel.LastName = model.LastName ?? userModel.LastName;
            userModel.Email = model.Email ?? userModel.Email;
            userModel.PasswordHash = model.PasswordHash ?? userModel.PasswordHash;
            userModel.Role = model.Role ?? userModel.Role;
            userModel.UpdatedAt = DateTime.UtcNow;
            var user = await _repo.UpdateUserAsync(userModel);
            if (user == Guid.Empty)
                return BadRequest();
            return CreatedAtAction(nameof(UpdateUser),user);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(Guid id) 
        {
            var user = await _repo.DeleteUserAsync(id);
            if (user == Guid.Empty)
                return BadRequest();
            return Ok(id);
        }

    }
}
