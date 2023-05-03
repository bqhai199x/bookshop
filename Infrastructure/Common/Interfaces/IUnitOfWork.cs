using Infrastructure.Repositories.Interfaces;

namespace Infrastructure.Common.Interfaces
{
    public interface IUnitOfWork : IUnitDb
    {
        ICategoryRepository Category { get; }

        IProductRepository Product { get; }

        IImageRepository Image { get; }
    }
}