using static System.Reflection.Metadata.BlobBuilder;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Author
    {
        [Key]
        public int author_id { get; set; }
        [Required]
        [MaxLength(100)]
        public string? first_name { get; set; }
        [Required]
        [MaxLength(100)]
        public string? last_name { get; set; }
        [Required]
        public DateOnly dob { get; set; }
        [Required]
        [MaxLength(100)]
        public string? nationality { get; set; }
        public ICollection<Books>? Books { get; set; }
    }
}
