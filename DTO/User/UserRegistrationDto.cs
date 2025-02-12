using LibraryManagementSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.DTO.User
{
    public class UserRegistrationDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public Role Role { get; set; }
    }
}
