using Entities;
using Utilities;

namespace WebApi.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<PaginatedList<Category>> GetAll(int pageIndex, int pageSize);

        Task<Category?> GetById(int id);

        Task<int> Add(Category category);

        Task<int> Delete(int id);

        Task<int> Update(Category category);
    }
}
