using System.ComponentModel.DataAnnotations;

namespace UserService.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }  // For storing hashed passwords
        [Required]
        public string Role { get; set; }  // Learner, Trainer, Admin
        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
