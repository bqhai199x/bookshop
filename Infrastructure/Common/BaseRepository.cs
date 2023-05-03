using Infrastructure.Common.Interfaces;
using SqlKata.Compilers;
using SqlKata.Execution;
using System.Data;

namespace Infrastructure.Common
{
    public class BaseRepository
    {
        protected readonly IDbFactory _dbFactory;

        public BaseRepository(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        protected IDbConnection DbConn => _dbFactory.Connection;

        protected IDbTransaction? DbTrans => _dbFactory.Transaction;

        private QueryFactory? _queryFactory;
        protected QueryFactory DbQuery => _queryFactory ??= new QueryFactory(DbConn, new MySqlCompiler());
    }
}
