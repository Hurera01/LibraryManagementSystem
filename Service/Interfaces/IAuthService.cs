using LibraryManagementSystem.DTO.User;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Service.Interfaces
{
    public interface IAuthService
    {
        public Task<User> RegisterUser(UserRegistrationDto userRegistrationDto);
    }
}
