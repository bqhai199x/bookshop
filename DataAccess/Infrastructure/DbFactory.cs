using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private BookStoreContext? _dbcontext;

        private IConfiguration _config;

        public DbFactory(IConfiguration config)
        {
            _config = config;
        }

        public BookStoreContext Init()
        {
            if (_dbcontext == null)
            {
                var optionsBuilder = new DbContextOptionsBuilder<BookStoreContext>();
                optionsBuilder.UseMySQL(_config.GetConnectionString("DefaultConnection") ?? string.Empty);
                _dbcontext = new BookStoreContext(optionsBuilder.Options);
            }
            return _dbcontext;
        }

        protected override void DisposeCore()
        {
            if(_dbcontext != null)
            {
                _dbcontext.Dispose();
            }
        }
    }
}
