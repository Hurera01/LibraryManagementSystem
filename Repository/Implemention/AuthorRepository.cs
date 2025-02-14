using System.Data;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.DTO.Author;
using LibraryManagementSystem.DTO.Book;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LibraryManagementSystem.Repository.Implemention
{
    public class AuthorRepository : IAuthorRepository
    {
        protected readonly ApplicationDbContext _context;
        //private readonly DbSet<T> _dbSet;

        public AuthorRepository(ApplicationDbContext context)
        {
            _context = context;
            //_dbSet = context.Set<T>();
        }
        public async Task Add(CreateAuthorDto author)
        {
            try
            {
                string storedProcedure = $"EXEC CreateAuthor @Authors, @StatusCode OUTPUT, @Message OUTPUT";

                var authorTable = new DataTable();
                authorTable.Columns.Add("first_name", typeof(string));
                authorTable.Columns.Add("last_name", typeof(string));
                authorTable.Columns.Add("dob", typeof(DateTime));
                authorTable.Columns.Add("nationality", typeof(string));

                authorTable.Rows.Add(author.first_name, author.last_name, author.dob, author.nationality);

                var authorParam = new SqlParameter("@Authors", SqlDbType.Structured)
                {
                    TypeName = "dbo.AuthorType", 
                    Value = authorTable
                };

                // Output parameters
                var statusCodeParam = new SqlParameter("@StatusCode", System.Data.SqlDbType.Int) { Direction = System.Data.ParameterDirection.Output };
                var messageParam = new SqlParameter("@Message", System.Data.SqlDbType.NVarChar, 255) { Direction = System.Data.ParameterDirection.Output };

                await _context.Database.ExecuteSqlRawAsync(storedProcedure, authorParam, statusCodeParam, messageParam);

                var statusCode = statusCodeParam.Value;
                var message = messageParam.Value.ToString();


                if ((int)statusCode != 0)
                {
                    throw new Exception($"Error creating Author: {message}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating Author: {ex.Message}");
            }
        }

        public async Task Delete(int author_id)
        {
            try
            {
                string storedProcedure = $"EXEC DeleteAuthor @p_author_id, @StatusCode OUTPUT, @Message OUTPUT";

                var authorIdParam = new SqlParameter("@p_author_id", SqlDbType.Int) { Value = author_id };
                var statusCodeParam = new SqlParameter("@StatusCode", SqlDbType.Int) { Direction = ParameterDirection.Output };
                var messageParam = new SqlParameter("@Message", SqlDbType.NVarChar, 255) { Direction = ParameterDirection.Output };

                await _context.Database.ExecuteSqlRawAsync(storedProcedure, authorIdParam, statusCodeParam, messageParam);

                var statusCode = (int)statusCodeParam.Value;
                var message = messageParam.Value.ToString();

                if (statusCode != 0)
                {
                    throw new Exception($"Error deleting Author: {message}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting Author: {ex.Message}");
            }
        }


        public async Task<GetAuthorDto> GetById(int author_id)
        {
            try
            {
                string storedProcedure = "EXEC GetAuthor @p_author_id";
                var authorInfoParam = new SqlParameter("@p_author_id", author_id);

                var command = _context.Database.GetDbConnection().CreateCommand();
                command.CommandText = storedProcedure;
                command.CommandType = CommandType.Text;
                command.Parameters.Add(authorInfoParam);

                await _context.Database.OpenConnectionAsync();
                var reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        var authorDto = new GetAuthorDto
                        {
                            author_id = reader.GetInt32(reader.GetOrdinal("author_id")),
                            firstname = reader.GetString(reader.GetOrdinal("first_name")),
                            lastname = reader.GetString(reader.GetOrdinal("last_name")),
                            dob = reader.GetDateTime(reader.GetOrdinal("dob")),
                            nationality = reader.GetString(reader.GetOrdinal("nationality"))
                        };

                        return authorDto;
                    }
                }

                throw new Exception("Author not found.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching Author: {ex.Message}");
            }
        }

        public async Task<UpdateAuthorDto> Update(int author_id, CreateAuthorDto author)
        {
            try
            {
                string storedProcedure = $"EXEC UpdateAuthor @p_author_id ,@Authors , @StatusCode OUTPUT, @Message OUTPUT";
                var authorIdParam = new SqlParameter("@p_author_id", SqlDbType.Int) { Value = author_id };
                var authorTable = new DataTable();
                authorTable.Columns.Add("first_name", typeof(string));
                authorTable.Columns.Add("last_name", typeof(string));
                authorTable.Columns.Add("dob", typeof(DateTime));
                authorTable.Columns.Add("nationality", typeof(string));

                authorTable.Rows.Add(author.first_name, author.last_name, author.dob, author.nationality);

                var authorParam = new SqlParameter("@Authors", SqlDbType.Structured)
                {
                    TypeName = "dbo.AuthorType",
                    Value = authorTable
                };

                // Output parameters
                var statusCodeParam = new SqlParameter("@StatusCode", System.Data.SqlDbType.Int) { Direction = System.Data.ParameterDirection.Output };
                var messageParam = new SqlParameter("@Message", System.Data.SqlDbType.NVarChar, 255) { Direction = System.Data.ParameterDirection.Output };

                await _context.Database.ExecuteSqlRawAsync(storedProcedure, authorIdParam, authorParam, statusCodeParam, messageParam);

                var statusCode = statusCodeParam.Value;
                var message = messageParam.Value.ToString();


                if ((int)statusCode != 0)
                {
                    throw new Exception($"Error Updating Author: {message}");
                }

                var updatedAuthor = await _context.Authors.Where(a => a.author_id == author_id)
                    .FirstOrDefaultAsync();

                var updatedAuthorDto = new UpdateAuthorDto
                {
                    author_id = updatedAuthor.author_id,
                    first_name = updatedAuthor.first_name,
                    last_name = updatedAuthor.last_name,
                    dob = updatedAuthor.dob,
                    nationality = updatedAuthor.nationality
                };

                return updatedAuthorDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating Author: {ex.Message}");
            }

        }


        //string storedProcedure = $"EXEC CreateAuthor @p_first_name, @p_last_name, @p_dob, @p_nationality, @StatusCode OUTPUT, @Message OUTPUT";

        //var firstNameParam = new SqlParameter("@p_first_name", author.first_name);
        //var lastNameParam = new SqlParameter("@p_last_name", author.last_name);
        //var dobParam = new SqlParameter("@p_dob", author.dob);
        //var nationalityParam = new SqlParameter("@p_nationality", author.nationality);

        //// Output parameters
        //var statusCodeParam = new SqlParameter("@StatusCode", System.Data.SqlDbType.Int) { Direction = System.Data.ParameterDirection.Output };
        //var messageParam = new SqlParameter("@Message", System.Data.SqlDbType.NVarChar, 255) { Direction = System.Data.ParameterDirection.Output };

        //await _context.Database.ExecuteSqlRawAsync(storedProcedure, firstNameParam, lastNameParam, dobParam, nationalityParam, statusCodeParam, messageParam);

        ////Author obj_Author = new Author { first_name = author.first_name, nationality = author.nationality, last_name = author.last_name, dob = author.dob };
        ////_context.Authors.Add(obj_Author);
        //var statusCode = statusCodeParam.Value;
        //var message = messageParam.Value.ToString();


        //        if ((int) statusCode != 0)
        //        {
        //            throw new Exception($"Error creating Author: {message}");
    }

}

