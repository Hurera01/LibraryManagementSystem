using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Books
    {
        [Key]
        public int book_id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }
        [Required]
        [ForeignKey("Author")]
        public int author_id { get; set; }
        [Required]
        [MaxLength(100)]
        public string? genre { get; set; }
        [Required]
        public int publish_year { get; set; }
        [Required]
        [MaxLength(50)]
        public string isbn { get; set; }
        public Author Authors { get; set; }
        public ICollection<Book_Category> Book_Categories { get; set; }
        public ICollection<Loans> Loans { get; set; }
    }
}
