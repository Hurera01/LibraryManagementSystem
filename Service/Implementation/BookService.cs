using LibraryManagementSystem.DTO;
using LibraryManagementSystem.Repository.Interfaces;
using LibraryManagementSystem.Service.Interfaces;

namespace LibraryManagementSystem.Service.Implementation
{
    public class BookService : IBookService
    {
        private readonly IBookRepository? _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task Add(BookDto book)
        {
            await _bookRepository.Add(book);
        }

        public Task Delete(int book_id)
        {
            throw new NotImplementedException();
        }

        public Task<BookDto> GetById(int book_id)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, BookDto book)
        {
            throw new NotImplementedException();
        }
    }
}
