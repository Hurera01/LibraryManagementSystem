using LibraryManagementSystem.Data;
using LibraryManagementSystem.DTO;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repository.Implemention
{
    public class CategoryRepository : ICategoryRepository
    {
        protected readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(CategoryDto category)
        {
            var storedProcedure = $"EXEC CreateCategory @p_category_name,@StatusCode OUTPUT,@Message OUTPUT";

            var categoryNameParam = new SqlParameter("@p_category_name", category.category_name);

            var statusCodeParam = new SqlParameter("@StatusCode", System.Data.SqlDbType.Int) { Direction = System.Data.ParameterDirection.Output };
            var messageParam = new SqlParameter("@Message", System.Data.SqlDbType.NVarChar, 255) { Direction = System.Data.ParameterDirection.Output };

            await _context.Database.ExecuteSqlRawAsync(storedProcedure, categoryNameParam, statusCodeParam, messageParam);

            var statusCode = statusCodeParam.Value;
            var message = messageParam.Value;

            if ((int)statusCode != 0)
            {
                throw new Exception($"Error Creating Category: {message}");
            }
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, CategoryDto category)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDto> GetById(int category_id)
        {
            throw new NotImplementedException();
        }
    }
}
