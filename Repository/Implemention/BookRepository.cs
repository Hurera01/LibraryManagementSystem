using Dapper;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.DTO.Book;
using LibraryManagementSystem.Repository.Interfaces;
using LibraryManagementSystem.Utility;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

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
            string storedProcedure = $"EXEC CreateBook @p_title, @p_author_id, @p_genre, @p_publish_year, @p_isbn, @StatusCode OUTPUT, @Message OUTPUT";

            var titleParam = new SqlParameter("@p_title", book.Title);
            var authorIdParam = new SqlParameter("@p_author_id", book.author_id);
            var genreParam = new SqlParameter("@p_genre", book.genre);
            var publishYearParam = new SqlParameter("@p_publish_year", book.publish_year);
            var isbnParam = new SqlParameter("@p_isbn", book.publish_year);

            var statusCodeParam = new SqlParameter("@StatusCode", System.Data.SqlDbType.Int) { Direction = System.Data.ParameterDirection.Output };
            var messageParam = new SqlParameter("@Message", System.Data.SqlDbType.NVarChar, 255) { Direction = System.Data.ParameterDirection.Output };

            await _context.Database.ExecuteSqlRawAsync(storedProcedure, titleParam, authorIdParam, genreParam, publishYearParam, isbnParam,statusCodeParam, messageParam);

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

        public async Task<BookDto> GetById(int book_id)
        {
            var book = await _context.books.FindAsync(book_id);
            var bookDto = new BookDto()
            {
                Title = book.Title,
                author_id = book.author_id,
                genre = book.genre,
                publish_year = book.publish_year,
                isbn = book.isbn,
            };
            return bookDto;
        }

        public async Task<Response<GetBookWithAuthorDto>> GetBookWithAuthor(int book_id)
        {
            using var connection = _context.Database.GetDbConnection();
            await connection.OpenAsync(); // Explicitly open the connection

            var param = new { p_book_id = book_id };

            var result = await connection.QueryFirstOrDefaultAsync<GetBookWithAuthorDto>(
                "dbo.GetBookWithAuthors",
                param: param,
                commandType: CommandType.StoredProcedure
            );

            return ResponseHelper.SuccessResponse(result);
        }

        public async Task<int> AddMultipleBooks(List<BookDto> books)
        {
            using var connection = _context.Database.GetDbConnection();
            await connection.OpenAsync();

            // Convert books list to DataTable
            var bookTable = new DataTable();
            bookTable.Columns.Add("Title", typeof(string));
            bookTable.Columns.Add("genre", typeof(string));
            bookTable.Columns.Add("publish_year", typeof(int));
            bookTable.Columns.Add("author_id", typeof(int));
            bookTable.Columns.Add("isbn", typeof(string));

            books.ForEach(book => bookTable.Rows.Add(book.Title, book.genre, book.publish_year, book.author_id, book.isbn));

            var parameters = new DynamicParameters();
            parameters.Add("@Books", bookTable.AsTableValuedParameter("dbo.BookTableType"));

            await connection.ExecuteAsync("InsertMultipleBooks", parameters, commandType: CommandType.StoredProcedure);

            return books.Count;
        }
    }
}
