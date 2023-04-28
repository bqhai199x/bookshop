namespace Infrastructure.Common.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();

        Task<T?> GetByIdAsync(int id);

        Task<int> AddAsync(T entity);

        Task<int> UpdateAsync(T entity);

        Task<int> DeleteAsync(int id);
    }
}
