using LibraryManagementSystem.DTO;
using LibraryManagementSystem.Repository.Interfaces;
using LibraryManagementSystem.Service.Interfaces;

namespace LibraryManagementSystem.Service.Implementation
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task Add(AuthorDto author)
        {
            await _authorRepository.Add(author);
        }

        public Task Delete(int author_id)
        {
            throw new NotImplementedException();
        }

        public Task<AuthorDto> GetById(int author_id)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, AuthorDto author)
        {
            throw new NotImplementedException();
        }
    }
}
