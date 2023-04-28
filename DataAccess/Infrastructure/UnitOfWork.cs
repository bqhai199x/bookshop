using DataAccess.Data;

namespace DataAccess.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory _dbFactory;

        private BookStoreContext? _dbContext;

        public BookStoreContext DbContext => _dbContext ?? (_dbContext = _dbFactory.Init());

        public UnitOfWork(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public int Commit()
        {
            return DbContext.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return DbContext.SaveChangesAsync();
        }
    }
}
