using Infrastructure.Common.Interfaces;
using SqlKata;
using SqlKata.Execution;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Infrastructure.Common
{
    public class GenericRepository<TEntity> : BaseRepository, IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly Query TableQuery;

        public GenericRepository(IDbFactory dbFactory) : base(dbFactory)
        {
            var table = typeof(TEntity).GetCustomAttribute<TableAttribute>();
            TableQuery = DbQuery.Query(table?.Name);
        }

        public virtual Query GetTableQuery()
        {
            return TableQuery;
        }

        public virtual async Task<int> Count(Query? query = null)
        {
            query ??= TableQuery;
            return await query.CountAsync<int>();
        }

        public virtual async Task<int> DeleteById(int id)
        {
            return await TableQuery.DeleteAsync(DbTrans);
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            var list = await TableQuery.GetAsync<TEntity>();
            return list.ToList();
        }

        public virtual async Task<TEntity?> FindById(int id)
        {
            var entity = await TableQuery.Where("Id", id).FirstOrDefaultAsync<TEntity>();
            return entity;
        }

        public virtual async Task<List<TEntity>> Filter(Query query)
        {
            var list = await query.GetAsync<TEntity>();
            return list.ToList();
        }

        public virtual async Task<TEntity> Find(Query query)
        {
            var entity = await query.FirstOrDefaultAsync<TEntity>();
            return entity;
        }
    }
}
