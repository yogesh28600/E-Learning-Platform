using System.ComponentModel.DataAnnotations;

namespace UserService.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }  // For storing hashed passwords
        public string Role { get; set; }  // Learner, Trainer, Admin
    }
}
