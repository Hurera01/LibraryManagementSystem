using LibraryManagementSystem.DTO.Author;

namespace LibraryManagementSystem.Repository.Interfaces
{
    public interface IAuthorRepository
    {
        Task Add(CreateAuthorDto author);
        Task<GetAuthorDto> GetById(int author_id);
        Task<UpdateAuthorDto> Update(int id, CreateAuthorDto author);
        Task Delete(int author_id);
    }
}
