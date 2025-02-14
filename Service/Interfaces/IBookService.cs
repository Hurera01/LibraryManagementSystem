using LibraryManagementSystem.DTO.Book;
using LibraryManagementSystem.Utility;



namespace LibraryManagementSystem.Service.Interfaces
{
    public interface IBookService
    {
        Task Add(BookDto book);
        Task<BookDto> GetById(int book_id);
        Task Update(int id, BookDto book);
        Task Delete(int book_id);
        Task<Response<GetBookWithAuthorDto>> GetBookWithAuthor(int book_id);
        Task<int> AddMultipleBooks(List<BookDto> books);
    }
}
