using LibraryManagementSystem.DTO.User;

namespace LibraryManagementSystem.Service.Interfaces
{
    public interface IUserService
    {
        Task<List<GetUserDto>> GetUser();
    }
}
