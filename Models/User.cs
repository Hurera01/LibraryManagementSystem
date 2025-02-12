using System.ComponentModel.DataAnnotations;
using System.Data;

namespace LibraryManagementSystem.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public Role Role { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
