using Entities;
using Infrastructure.Common.Interfaces;
using Utilities;
using WebApi.Base;
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

        public async Task<PaginatedList<Product>> GetAll(int pageIndex, int pageSize)
        {
            int total = await _unitOfWork.Product.Count();
            int totalPages = (int)Math.Ceiling(total / (double)pageSize);
            if (pageIndex > totalPages || pageIndex < 1) pageIndex = 1;
            List<Product> productList = await _unitOfWork.Product.GetAll(pageIndex, pageSize);
            if (productList.Count == 0)
            {
                throw new NoDataException();
            }
            var result = new PaginatedList<Product>(productList, total, pageIndex, pageSize);
            return result;
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
