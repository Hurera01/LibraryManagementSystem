using LibraryManagementSystem.DTO;
using LibraryManagementSystem.Repository.Interfaces;
using LibraryManagementSystem.Service.Interfaces;

namespace LibraryManagementSystem.Service.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task Add(CategoryDto category)
        {
            await _categoryRepository.Add(category);
        }

        public Task Delete(int category_id)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDto> GetById(int category_id)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, CategoryDto category)
        {
            throw new NotImplementedException();
        }
    }
}
