using LibraryManagementSystem.DTO;
using LibraryManagementSystem.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;  // Service to handle business logic

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        // POST api/author
        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] AuthorDto author)
        {
            if (author == null)
            {
                return BadRequest("Author object is null.");
            }

            try
            {
                await _authorService.Add(author);

                return Ok(new { message = "Author created successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
