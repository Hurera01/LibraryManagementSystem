using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Categories
    {
        [Key]
        public int category_id { get; set; }
        [Required]
        [MaxLength(100)]
        public string? category_name { get; set; }
        public ICollection<Book_Category> Book_Categories { get; set; }
    }
}
