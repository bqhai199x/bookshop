using DataAccess.Infrastructure;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Utilities;

namespace BusinessLogic.BaseServices
{
    public class BaseServices<TEntity> : IBaseServices<TEntity> where TEntity : class
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IGenericRepository<TEntity> _repository;

        public BaseServices(IUnitOfWork unitOfWork, IGenericRepository<TEntity> genericRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = genericRepository;
        }

        public virtual int Count()
        {
            return _repository.Count();
        }

        public virtual async Task<int> CountAsync()
        {
            return await _repository.CountAsync();
        }

        public virtual int Create(TEntity entity)
        {
            _repository.Add(entity);
            return _unitOfWork.Commit();
        }

        public virtual async Task<int> CreateAsync(TEntity entity)
        {
            _repository.Add(entity);
            return await _unitOfWork.CommitAsync();
        }

        public bool Delete(TEntity entity)
        {
            _repository.Delete(entity);
            return _unitOfWork.Commit() > 0;
        }

        public virtual async Task<bool> DeleteAsync(TEntity entity)
        {
            _repository.Delete(entity);
            return await _unitOfWork.CommitAsync() > 0;
        }

        public bool DeleteById(object id)
        {
            var entity = _repository.GetById(id);
            if (entity == null) return false;
            _repository.Delete(entity);
            return _unitOfWork.Commit() > 0;
        }

        public virtual async Task<bool> DeleteByIdAsync(object id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;
            _repository.Delete(entity);
            return await _unitOfWork.CommitAsync() > 0;
        }

        public virtual TEntity? Find(Expression<Func<TEntity, bool>> filter)
        {
            return _repository.Find(filter);
        }

        public virtual IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> filter)
        {
            return _repository.FindAll(filter);
        }

        public virtual async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _repository.FindAllAsync(filter);
        }

        public virtual async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _repository.FindAsync(filter);
        }

        public virtual TEntity? FindInclude(Expression<Func<TEntity, bool>> filter, string includeProperties = "")
        {
            var query = _repository.FindBy(filter);
            foreach (var item in includeProperties.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(item);
            }
            return query.FirstOrDefault();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public virtual async Task<PaginatedList<TEntity>>
            GetAdvancedAsync(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>>? orderBy = null, string includeProperties = "", int page = 1, int pageSize = 10)
        {
            var query = _repository.Get(filter: filter, includeProperties: includeProperties);
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            return await PaginatedList<TEntity>.CreateAsync(query.AsNoTracking(), page, pageSize);
        }

        public virtual PaginatedList<TEntity>
            GetAdvanced(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>>? orderBy = null, string includeProperties = "", int page = 1, int pageSize = 10)
        {
            var query = _repository.Get(filter: filter, includeProperties: includeProperties);
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            return PaginatedList<TEntity>.Create(query.AsNoTracking(), page, pageSize);
        }

        public virtual TEntity? GetById(object id)
        {
            return _repository.GetById(id);
        }

        public virtual async Task<TEntity?> GetByIdAsync(object id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public virtual IEnumerable<TEntity> GetTop(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, int top = 0)
        {
            IQueryable<TEntity> query;
            query = _repository.GetAll();
            if (orderBy != null)
            {
                query = orderBy(_repository.GetAll());
            }
            if (top != 0)
            {
                query = query.Take(top);
            }
            return query.ToList();
        }

        public virtual bool Update(TEntity entity)
        {
            _repository.Update(entity);
            return _unitOfWork.Commit() > 0;
        }

        public virtual async Task<bool> UpdateAsync(TEntity entity)
        {
            _repository.Update(entity);
            return await _unitOfWork.CommitAsync() > 0;
        }
    }
}
