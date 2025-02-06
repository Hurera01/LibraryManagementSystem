using LibraryManagementSystem.DTO;

namespace LibraryManagementSystem.Service.Interfaces
{
    public interface ICategoryService
    {
        Task Add(CategoryDto category);
        Task<CategoryDto> GetById(int category_id);
        Task Update(int id, CategoryDto category);
        Task Delete(int category_id);
    }
}
