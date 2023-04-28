using System.Linq.Expressions;

namespace DataAccess.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);

        void Update(TEntity entity);

        TEntity Delete(TEntity entity);

        void DeleteBy(Expression<Func<TEntity, bool>> filter);

        int Count();

        Task<int> CountAsync();

        TEntity? GetById(object id);

        Task<TEntity?> GetByIdAsync(object id);

        IQueryable<TEntity> GetAll();

        Task<IEnumerable<TEntity>> GetAllAsync();

        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "");

        TEntity? Find(Expression<Func<TEntity, bool>> filter);

        Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> filter);

        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> filter);

        Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> filter);

        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> filter);
    }
}