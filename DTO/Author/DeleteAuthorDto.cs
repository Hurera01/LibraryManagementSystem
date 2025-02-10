using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.DTO.Author
{
    public class DeleteAuthorDto
    {
        [Required]
        public int author_id { get; set; }
    }
}
