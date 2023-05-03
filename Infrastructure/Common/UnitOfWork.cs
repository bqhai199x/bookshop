using Infrastructure.Common.Interfaces;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Interfaces;

namespace Infrastructure.Common
{
    public class UnitOfWork : UnitDb, IUnitOfWork
    {
        public UnitOfWork(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        private ICategoryRepository? _category;
        public ICategoryRepository Category => _category ??= new CategoryRepository(DbFactory);

        private IProductRepository? _product;
        public IProductRepository Product => _product ??= new ProductRepository(DbFactory);

        private IImageRepository? _image;
        public IImageRepository Image => _image ??= new ImageRepository(DbFactory);
    }
}
