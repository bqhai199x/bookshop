using Entities;

namespace WebApi.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProduct();

        Task<Product?> GetProductById(int id);
    }
}
