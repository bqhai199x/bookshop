using Entities;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();

        Task<Product?> GetById(int id);

        Task<int> Add(Product product);

        Task<int> Update(Product product);

        Task<int> Delete(int id);
    }
}
