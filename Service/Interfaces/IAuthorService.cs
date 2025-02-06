using LibraryManagementSystem.DTO;

namespace LibraryManagementSystem.Service.Interfaces
{
    public interface IAuthorService
    {
        Task Add(AuthorDto author);
        Task<AuthorDto> GetById(int author_id);
        Task Update(int id, AuthorDto author);
        Task Delete(int author_id);
    }
}
