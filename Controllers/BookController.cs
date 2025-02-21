using LibraryManagementSystem.DTO.Book;
using LibraryManagementSystem.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] BookDto book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _bookService.Add(book);
                return Ok(new { message = "Book Created Successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");

            }

        }

        [HttpGet]
        public async Task<IActionResult> GetBookWithAuthor(int book_id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _bookService.GetBookWithAuthor(book_id);
                return Ok(new { message = "Retrieve book with author successfully", data = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }
        
        [HttpGet("GetBookById")]
        public async Task<IActionResult> GetBookById(int book_id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var result = await _bookService.GetById(book_id);
                return Ok(new { message = "Retrieve book with author successfully", data = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        [HttpPost("AddMultipleBooks")]
        public async Task<IActionResult> AddMultipleBooks([FromBody] List<BookDto> books)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _bookService.AddMultipleBooks(books);
                return Ok(new { message = "Added Muliple Books Successfully", data = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
