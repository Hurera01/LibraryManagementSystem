using LibraryManagementSystem.Data;
using LibraryManagementSystem.DTO;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

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
        public async Task Add(AuthorDto author)
        {
            try
            {
                string storedProcedure = $"EXEC CreateAuthor @p_first_name, @p_last_name, @p_dob, @p_nationality, @StatusCode OUTPUT, @Message OUTPUT";

                var firstNameParam = new SqlParameter("@p_first_name", author.first_name);
                var lastNameParam = new SqlParameter("@p_last_name", author.last_name);
                var dobParam = new SqlParameter("@p_dob", author.dob);
                var nationalityParam = new SqlParameter("@p_nationality", author.nationality);

                // Output parameters
                var statusCodeParam = new SqlParameter("@StatusCode", System.Data.SqlDbType.Int) { Direction = System.Data.ParameterDirection.Output };
                var messageParam = new SqlParameter("@Message", System.Data.SqlDbType.NVarChar, 255) { Direction = System.Data.ParameterDirection.Output };

                await _context.Database.ExecuteSqlRawAsync(storedProcedure, firstNameParam, lastNameParam, dobParam, nationalityParam, statusCodeParam, messageParam);

                Author obj_Author = new Author { first_name = author.first_name, nationality = author.nationality, last_name = author.last_name, dob = author.dob };
                _context.Authors.Add(obj_Author);
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

        public Task Delete(int author_id)
        {
            throw new NotImplementedException();
        }

        public Task<AuthorDto> GetById(int author_id)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, AuthorDto author)
        {
            throw new NotImplementedException();
        }

    }
}
