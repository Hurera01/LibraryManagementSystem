namespace LibraryManagementSystem.DTO.Book
{
    public class GetPaginatedBooksDto
    {
        public IEnumerable<PaginatedBooksDto> Books { get; set; }
        public int TotalCount { get; set; }
    }
}
