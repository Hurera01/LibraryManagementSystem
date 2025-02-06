using LibraryManagementSystem.DTO;

namespace LibraryManagementSystem.Repository.Interfaces
{
    public interface IBookRepository
    {
        Task Add(BookDto book);
        Task<BookDto> GetById(int book_id);
        Task Update(int id, BookDto book);
        Task Delete(int book_id);
    }
}
