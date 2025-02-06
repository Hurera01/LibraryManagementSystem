namespace LibraryManagementSystem.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task Add(T entity);
        Task Update(int id, T entity);
        Task Delete(int id);
    }
}
