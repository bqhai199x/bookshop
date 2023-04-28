using BusinessLogic.BaseServices;
using DataAccess.Infrastructure;
using DataAccess.Repositories;
using Entities;

namespace BusinessLogic.Services
{
    public class ProductServices : BaseServices<Product>, IProductServices
    {
        public ProductServices(IUnitOfWork unitOfWork, IGenericRepository<Product> genericRepository) : base(unitOfWork, genericRepository) { }

        public List<Product> GetAllProduct()
        {
        }
    }
}
