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

        public async Task<int> Add(Product product)
        {
            int id = await _unitOfWork.Product.Add(product);
            return id;
        }

        public async Task<int> Delete(int id)
        {
            int result = await _unitOfWork.Product.Delete(id);
            return result;
        }

        public async Task<List<Product>> GetAll()
        {
            List<Product> productList = await _unitOfWork.Product.GetAll();
            return productList;
        }

        public async Task<Product?> GetById(int id)
        {
            Product? product = await _unitOfWork.Product.GetById(id);
            return product;
        }

        public async Task<int> Update(Product product)
        {
            int result = await _unitOfWork.Product.Update(product);
            return result;
        }
    }
}
