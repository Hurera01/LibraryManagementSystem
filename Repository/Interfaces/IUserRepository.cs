using LibraryManagementSystem.DTO.User;

namespace LibraryManagementSystem.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<List<GetUserDto>> GetAllUser();
    }
}
