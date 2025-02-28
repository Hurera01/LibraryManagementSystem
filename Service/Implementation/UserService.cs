using LibraryManagementSystem.DTO.User;
using LibraryManagementSystem.Repository.Interfaces;
using LibraryManagementSystem.Service.Interfaces;

namespace LibraryManagementSystem.Service.Implementation
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<List<GetUserDto>> GetUser()
        {
            return _userRepository.GetAllUser();
        }
    }
}
