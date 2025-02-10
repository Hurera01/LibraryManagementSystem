using LibraryManagementSystem.DTO.Author;

namespace LibraryManagementSystem.Service.Interfaces
{
    public interface IAuthorService
    {
        Task Add(CreateAuthorDto author);
        Task<GetAuthorDto> GetById(int author_id);
        Task Update(int id, CreateAuthorDto author);
        Task Delete(int author_id);
    }
}
