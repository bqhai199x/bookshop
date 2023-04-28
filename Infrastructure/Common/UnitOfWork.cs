using Infrastructure.Common.Interfaces;
using Infrastructure.Repositories.Interfaces;

namespace Infrastructure.Common
{
    public class UnitOfWork : UnitRepository, IUnitOfWork
    {
        public IDbFactory DbFactory { get; }

        public UnitOfWork(IDbFactory dbFactory, ICategoryRepository category, IProductRepository product, IOrderRepository order) : base(category, product, order)
        {
            DbFactory = dbFactory;
        }

        public void BeginTransaction()
        {
            DbFactory.Trans = DbFactory.Conn.BeginTransaction();
        }

        public void Commit()
        {
            DbFactory.Trans?.Commit();
            Dispose();
        }

        public void Rollback()
        {
            DbFactory.Trans?.Rollback();
            Dispose();
        }

        public void Dispose() => DbFactory.Trans?.Dispose();
    }
}
