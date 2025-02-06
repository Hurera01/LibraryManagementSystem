using LibraryManagementSystem.DTO;

namespace LibraryManagementSystem.Repository.Interfaces
{
    public interface ICategoryRepository
    {
        Task Add(CategoryDto category);
        Task<CategoryDto> GetById(int category_id);
        Task Update(int id, CategoryDto category);
        Task Delete(int category_id);
    }
}
