using Entities;

namespace Infrastructure.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAll(int pageIndex, int pageSize);

        Task<Category?> GetById(int id);

        Task<int> Add(Category category);

        Task<int> Update(Category category);

        Task<int> Delete(int id);

        Task<int> Count();
    }
}
