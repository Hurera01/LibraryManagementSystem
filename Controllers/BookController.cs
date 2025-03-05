using LibraryManagementSystem.Data;
using LibraryManagementSystem.DTO.Book;
using LibraryManagementSystem.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly ApplicationDbContext _context;

        public BookController(IBookService bookService, ApplicationDbContext context)
        {
            _bookService = bookService;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromForm] BookDto book, IFormFile imageFile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _bookService.Add(book, imageFile);
                return Ok(new { message = "Book Created Successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");

            }

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var book = await _context.books.FindAsync(id);
                if(book != null)
                {
                    _context.Remove(book);
                    _context.SaveChanges();
                }
                return Ok(new { message = "Book Deleted Successfully" });
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

        [HttpGet("GetPaginatedBooks")]
        [Authorize(Roles = "Admin, Librarian")]
        public async Task<IActionResult> GetPaginatedBooks(int pageNumber, int pageSize)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var result = await _bookService.GetPaginatedBooks(pageNumber, pageSize);
                return Ok(new { Books = result.Books, TotalCount = result.TotalCount });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
