using Entities;
using BusinessLogic.BaseServices;

namespace BusinessLogic.Services
{
    public interface IProductServices : IBaseServices<Product>
    {
        List<Product> GetAllProduct();
    }
}
