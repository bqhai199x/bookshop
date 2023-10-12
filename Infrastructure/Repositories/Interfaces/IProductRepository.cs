using Entities;
using Infrastructure.Common.Interfaces;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<int> Add(Product product);

        Task<int> Update(Product product);
    }
}
