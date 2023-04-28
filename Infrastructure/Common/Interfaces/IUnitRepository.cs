using Infrastructure.Repositories.Interfaces;

namespace Infrastructure.Common.Interfaces
{
    public interface IUnitRepository
    {
        ICategoryRepository Category { get; }

        IProductRepository Product { get; }

        IOrderRepository Order { get; }
    }
}
