using Infrastructure.Common.Interfaces;

namespace Infrastructure.Common
{
    public class UnitDb : Disposable, IUnitDb
    {
        public IDbFactory DbFactory { get; }

        public UnitDb(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
        }

        public void BeginTransaction()
        {
            DbFactory.Transaction = DbFactory.Connection.BeginTransaction();
        }

        public void Commit()
        {
            DbFactory.Transaction?.Commit();
            Dispose();
        }

        public void Rollback()
        {
            DbFactory.Transaction?.Rollback();
            Dispose();
        }

        protected override void DisposeCore() => DbFactory.Transaction?.Dispose();
    }
}
