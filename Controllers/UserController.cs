using LibraryManagementSystem.Data;
using LibraryManagementSystem.DTO.User;
using LibraryManagementSystem.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        protected readonly ApplicationDbContext _context;

        public UserController(IUserService userService, ApplicationDbContext context)
        {
            _userService = userService;
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Librarian")]
        public async Task<IActionResult> GetAllUser(int page, int size)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var totalUsers = await _context.Users.CountAsync();

                var users = await _context.Users
                .Skip((page - 1) * size) 
                .Take(size)
                .Select(u => new GetUserDto
                {
                    UserId = u.UserId,
                    Email = u.Email,
                    FirstName = u.FirstName,
                    LastName = u.LastName
                })
                .ToListAsync();
                return Ok(new { Users = users, TotalCount = totalUsers });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> deleteUser(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var user = await _context.Users.FindAsync(id);
                if (user != null)
                {
                    _context.Remove(user);
                    _context.SaveChanges();
                }
                return Ok(new { message = "User Deleted Successfully" });
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> updateUser(int userId, [FromBody] UpdateUserDto updateUserDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var existingUser = _context.Users.FirstOrDefault(u => u.UserId == userId);
                if (existingUser != null)
                {
                    existingUser.FirstName = updateUserDto.FirstName;
                    existingUser.LastName = updateUserDto.LastName;
                    existingUser.Email = updateUserDto.Email;
                    existingUser.Role = updateUserDto.Role;
                }
                _context.SaveChanges();
                return Ok(new { message = "User Update Successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
