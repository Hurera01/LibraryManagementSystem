using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.DTO
{
    public class CategoryDto
    {
        [Required]
        public string? category_name { get; set; }
    }
}
