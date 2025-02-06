using LibraryManagementSystem.Data;
using LibraryManagementSystem.DTO;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repository.Implemention
{
    public class BookRepository : IBookRepository
    {
        protected readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(BookDto book)
        {
            string storedProcedure = $"EXEC CreateBook @p_title, @p_author_id, @p_genre, @p_publish_year, @StatusCode OUTPUT, @Message OUTPUT";

            var titleParam = new SqlParameter("@p_title", book.Title);
            var authorIdParam = new SqlParameter("@p_author_id", book.author_id);
            var genreParam = new SqlParameter("@p_genre", book.genre);
            var publishYearParam = new SqlParameter("p_publish_year", book.publish_year);

            var statusCodeParam = new SqlParameter("@StatusCode", System.Data.SqlDbType.Int) { Direction = System.Data.ParameterDirection.Output };
            var messageParam = new SqlParameter("@Message", System.Data.SqlDbType.NVarChar, 255) { Direction = System.Data.ParameterDirection.Output };

            await _context.Database.ExecuteSqlRawAsync(storedProcedure, titleParam, authorIdParam, genreParam, publishYearParam, statusCodeParam, messageParam);

            var statusCode = statusCodeParam.Value;
            var message = messageParam.Value;

            if ((int)statusCode != 0)
            {
                throw new Exception($"Error creating Book: {message}");
            }
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, BookDto book_id)
        {
            throw new NotImplementedException();
        }

        public Task<BookDto> GetById(int book_id)
        {
            throw new NotImplementedException();
        }
    }
}
