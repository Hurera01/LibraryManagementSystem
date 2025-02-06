using LibraryManagementSystem.DTO;



namespace LibraryManagementSystem.Service.Interfaces
{
    public interface IBookService
    {
        Task Add(BookDto book);
        Task<BookDto> GetById(int book_id);
        Task Update(int id, BookDto book);
        Task Delete(int book_id);
    }
}
