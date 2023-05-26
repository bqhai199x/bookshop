using Entities;
using Utilities;

namespace WebApi.Services.Interfaces
{
    public interface IProductService
    {
        Task<PaginatedList<Product>> GetAll(int pageIndex, int pageSize);

        Task<Product?> GetById(int id);

        Task<int> Add(Product product);

        Task<int> Delete(int id);

        Task<int> Update(Product product);
    }
}
