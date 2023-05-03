using Entities;

namespace WebApi.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAll();

        Task<Product?> GetById(int id);

        Task<int> Add(Product product);

        Task<int> Delete(int id);

        Task<int> Update(Product product);
    }
}
