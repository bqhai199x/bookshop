using Entities;
using Infrastructure.Common.Interfaces;

namespace Infrastructure.Repositories.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<int> Add(Category category);

        Task<int> Update(Category category);
    }
}
