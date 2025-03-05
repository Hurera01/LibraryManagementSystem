using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.DTO.Book
{
    public class BookDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public int author_id { get; set; }
        [Required]
        public string genre { get; set; }
        [Required]
        public int publish_year { get; set; }
        [Required]
        public string isbn { get; set; }
        [Required]
        public int quantity { get; set; }
        public string image_url {  get; set; }
    }
}
