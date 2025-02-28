using LibraryManagementSystem.Data;
using LibraryManagementSystem.DTO.User;
using LibraryManagementSystem.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repository.Implemention
{
    public class UserRepository : IUserRepository
    {
        protected readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetUserDto>> GetAllUser()
        {
            var user = await _context.Users.
                Select(u => new GetUserDto
                {
                    UserId = u.UserId,
                    Email = u.Email,
                    FirstName = u.FirstName,
                    LastName = u.LastName

                }).ToListAsync();
            return user;
        }
    }
}
