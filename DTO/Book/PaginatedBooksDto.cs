namespace LibraryManagementSystem.DTO.Book
{
    public class PaginatedBooksDto
    {   
        public int book_id { get; set; }
        public string Title { get; set; }
        public string genre { get; set; }
        public int publish_year { get; set; }
        public string author_name { get; set; }
    }
}
