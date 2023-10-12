using Infrastructure.Repositories.Interfaces;

namespace Infrastructure.Common.Interfaces
{
    public interface IUnitOfWork : IUnitDb
    {
        IAccountRepository Account { get; }

        ICategoryRepository Category { get; }

        IProductRepository Product { get; }

        IImageRepository Image { get; }
    }
}