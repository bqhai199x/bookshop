using Entities;

namespace WebApi.Services.Interfaces
{
    public interface IProductService
    {
        Task<int> Count();

        Task<List<Product>> GetAll(int pageIndex, int pageSize);

        Task<Product?> GetById(int id);

        Task<int> Add(Product product);

        Task<int> Delete(int id);

        Task<int> Update(Product product);
    }
}
