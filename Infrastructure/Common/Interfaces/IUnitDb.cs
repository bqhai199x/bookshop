namespace Infrastructure.Common.Interfaces
{
    public interface IUnitDb
    {
        void BeginTransaction();

        void Commit();

        void Rollback();
    }
}
