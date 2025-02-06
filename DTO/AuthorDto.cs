using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.DTO
{
    public class AuthorDto
    {
        [Required]
        public string? first_name { get; set; }
        [Required]
        public string? last_name { get; set; }
        [Required]
        public DateOnly dob { get; set; }
        [Required]
        public string? nationality { get; set; }
    }
}
