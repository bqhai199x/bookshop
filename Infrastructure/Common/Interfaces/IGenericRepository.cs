using SqlKata;

namespace Infrastructure.Common.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Query GetTableQuery();

        Task<List<TEntity>> GetAll();

        Task<TEntity?> FindById(int id);

        Task<int> Count(Query? query = null);

        Task<int> DeleteById(int id);

        Task<List<TEntity>> Filter(Query query);

        Task<TEntity> Find(Query query);
    }
}
