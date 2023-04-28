using DataAccess.Data;
using DataAccess.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private BookStoreContext? _dbContext;

        private readonly DbSet<TEntity> _dbSet;

        protected IDbFactory DbFactory { get; set; }

        protected BookStoreContext DbContext => _dbContext ?? (_dbContext = DbFactory.Init());

        public GenericRepository(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            _dbSet = DbContext.Set<TEntity>();
        }

        public virtual TEntity Add(TEntity entity)
        {
            return _dbSet.Add(entity).Entity;
        }

        public virtual int Count()
        {
            return _dbSet.Count();
        }

        public virtual Task<int> CountAsync()
        {
            return _dbSet.CountAsync();
        }

        public virtual TEntity Delete(TEntity entity)
        {
            if (_dbContext?.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            return _dbSet.Remove(entity).Entity;
        }

        public virtual void DeleteBy(Expression<Func<TEntity, bool>> filter)
        {
            IEnumerable<TEntity> entities = _dbSet.Where(filter).AsEnumerable();
            _dbSet.RemoveRange(entities);
        }

        public virtual TEntity? Find(Expression<Func<TEntity, bool>> filter)
        {
            return _dbSet.Where(filter).FirstOrDefault();
        }

        public virtual IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> filter)
        {
            return _dbSet.Where(filter).ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _dbSet.Where(filter).ToListAsync();
        }

        public virtual async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _dbSet.Where(filter).FirstOrDefaultAsync();
        }

        public virtual IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> filter)
        {
            return _dbSet.Where(filter);
        }

        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            return orderBy != null ? orderBy(query) : query;
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual TEntity? GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual async Task<TEntity?> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}
