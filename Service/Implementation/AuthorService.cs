using LibraryManagementSystem.DTO.Author;
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

        public async Task Add(CreateAuthorDto author)
        {
            await _authorRepository.Add(author);
        }

        public async Task Delete(int author_id)
        {
            await _authorRepository.Delete(author_id);
        }

        public async Task<GetAuthorDto> GetById(int author_id)
        {
            return await _authorRepository.GetById(author_id);
        }

        public Task Update(int id, CreateAuthorDto author)
        {
            throw new NotImplementedException();
        }
    }
}
