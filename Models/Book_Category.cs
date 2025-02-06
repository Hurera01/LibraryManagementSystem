using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Book_Category
    {
        [Required]
        public int book_id { get; set; }
        public Books Books { get; set; }
        //[Key]
        [Required]
        public int category_id { get; set; }
        public Categories Categories { get; set; }
    }
}
