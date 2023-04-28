namespace Infrastructure.Common.Interfaces
{
    public interface IUnitOfWork : IUnitRepository
    {
        void BeginTransaction();

        void Commit();

        void Rollback();
    }
}
