using LibraryManagementSystem.Data;
using LibraryManagementSystem.DTO.User;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Service.Implementation;
using LibraryManagementSystem.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly IAuthService _authService;
        public readonly JwtService _jwtService;
        public readonly ApplicationDbContext _context;

        public AuthController(IAuthService authService, JwtService jwtService, ApplicationDbContext context)
        {
            _authService = authService;
            _jwtService = jwtService;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDto userRegistrationDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (!Enum.IsDefined(typeof(Role), userRegistrationDTO.Role))
                {
                    return BadRequest("Invalid role provided.");
                }
                var user = await _authService.RegisterUser(userRegistrationDTO);
                return Ok(new { message = "User registered successfully", userId = user.UserId });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == userLoginDto.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(userLoginDto.Password, user.PasswordHash))
            {
                return Unauthorized(new { message = "Invalid email or password" });
            }

            var token = _jwtService.GenerateJwtToken(user);
            return Ok(new { token, userId = user.UserId, role = user.Role.ToString() });
        }

    }
}
