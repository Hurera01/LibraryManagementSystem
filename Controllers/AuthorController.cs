using LibraryManagementSystem.DTO.Author;
using LibraryManagementSystem.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    //[Authorize]
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
        //[Authorize(Roles = "Admin, Librarian")]
        public async Task<IActionResult> CreateAuthor([FromBody] CreateAuthorDto author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
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

        [HttpDelete]
        [Authorize(Roles = "Admin, Librarian")]
        public async Task<IActionResult> DeleteAuthor(int author_id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _authorService.Delete(author_id);

                return Ok(new { message = "Author Deleted Successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Librarian, Member")]
        public async Task<IActionResult> GetById(int author_id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _authorService.GetById(author_id);
                return Ok(new { message = "Author Retrieved Successfully.", data = result});
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut]
        [Authorize(Roles = "Admin,Librarian")]
        public async Task<IActionResult> Update(int author_id, CreateAuthorDto author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _authorService.Update(author_id, author);
                return Ok(new { message = "Author Update Successfully.", data = result });
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal server error: {{ex.Message}}");
            }
        }
    }
}
