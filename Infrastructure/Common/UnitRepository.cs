using Infrastructure.Common.Interfaces;
using Infrastructure.Repositories.Interfaces;

namespace Infrastructure.Common
{
    public class UnitRepository : IUnitRepository
    {
        public UnitRepository(ICategoryRepository category, IProductRepository product, IOrderRepository order)
        {
            Category = category;
            Product = product;
            Order = order;
        }

        public ICategoryRepository Category { get; }

        public IProductRepository Product { get; }

        public IOrderRepository Order { get; }
    }
}
