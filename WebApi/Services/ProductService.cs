using Entities;
using Infrastructure.Common.Interfaces;
using WebApi.Services.Interfaces;

namespace WebApi.Services
{
    public class ProductService : BaseService, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<List<Product>> GetAllProduct()
        {
            return await _unitOfWork.Product.GetAllAsync();
        }

        public async Task<Product?> GetProductById(int id)
        {
            return await _unitOfWork.Product.GetByIdAsync(id);
        }
    }
}
