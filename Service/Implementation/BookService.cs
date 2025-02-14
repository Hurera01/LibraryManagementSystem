using LibraryManagementSystem.DTO.Book;
using LibraryManagementSystem.Repository.Interfaces;
using LibraryManagementSystem.Service.Interfaces;
using LibraryManagementSystem.Utility;

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

        public Task<int> AddMultipleBooks(List<BookDto> books)
        {
            return _bookRepository.AddMultipleBooks(books);
        }

        public Task Delete(int book_id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<GetBookWithAuthorDto>> GetBookWithAuthor(int book_id)
        {
            return _bookRepository.GetBookWithAuthor(book_id);
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
