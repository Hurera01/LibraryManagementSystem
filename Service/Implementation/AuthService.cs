using LibraryManagementSystem.Data;
using LibraryManagementSystem.DTO.User;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Service.Implementation
{
    public class AuthService : IAuthService
    {
        public readonly ApplicationDbContext _context;

        public AuthService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> RegisterUser(UserRegistrationDto userRegistrationDto)
        {
            if (await _context.Users.AnyAsync(u => u.Email == userRegistrationDto.Email))
            {
                throw new Exception("Email is already in use.");
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(userRegistrationDto.Password);

            var user = new User
            {
                Email = userRegistrationDto.Email,
                PasswordHash = passwordHash,
                FirstName = userRegistrationDto.FirstName,
                LastName = userRegistrationDto.LastName,
                Role = userRegistrationDto.Role,
                CreatedAt = DateTime.UtcNow
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
