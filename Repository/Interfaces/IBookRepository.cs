using LibraryManagementSystem.DTO.Book;
using LibraryManagementSystem.Utility;

namespace LibraryManagementSystem.Repository.Interfaces
{
    public interface IBookRepository
    {
        Task Add(BookDto book, IFormFile imageFile);
        Task<BookDto> GetById(int book_id);
        Task Update(int id, BookDto book);
        Task Delete(int book_id);
        Task<Response<GetBookWithAuthorDto>> GetBookWithAuthor(int book_id);
        Task<int> AddMultipleBooks(List<BookDto> books);
        Task<GetPaginatedBooksDto> GetPaginatedBooks(int pageNumber, int pageSize);
    }
}
