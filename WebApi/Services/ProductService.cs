using AutoMapper;
using Entities;
using Infrastructure.Common.Interfaces;
using SqlKata;
using WebApi.Services.Interfaces;

namespace WebApi.Services
{
    public class ProductService : BaseService, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<int> Add(Product product)
        {
            int id = await _unitOfWork.Product.Add(product);
            return id;
        }

        public async Task<int> Count()
        {
            int count = await _unitOfWork.Product.Count();
            return count;
        }

        public async Task<int> Delete(int id)
        {
            int result = await _unitOfWork.Product.DeleteById(id);
            return result;
        }

        public async Task<List<Product>> GetAll(int pageIndex, int pageSize)
        {
            Query query = _unitOfWork.Product.GetTableQuery().Skip((pageIndex - 1) * pageSize).Take(pageSize);
            List<Product> productList = await _unitOfWork.Product.Filter(query);
            return productList;
        }

        public async Task<Product?> GetById(int id)
        {
            Product? product = await _unitOfWork.Product.FindById(id);
            return product;
        }

        public async Task<int> Update(Product product)
        {
            int result = await _unitOfWork.Product.Update(product);
            return result;
        }
    }
}
