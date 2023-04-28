using Infrastructure.Common.Interfaces;
using SqlKata.Compilers;
using SqlKata.Execution;
using System.Data;

namespace Infrastructure.Common
{
    public class BaseRepository
    {
        protected readonly IDbFactory _dbFactory;

        protected IDbConnection DbConn => _dbFactory.Conn;

        protected IDbTransaction? DbTrans => _dbFactory.Trans;

        private QueryFactory? _queryFactory;

        protected QueryFactory DbFactory => _queryFactory ?? GetQueryFactory();

        public BaseRepository(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        protected QueryFactory GetQueryFactory()
        {
            _queryFactory = new QueryFactory(DbConn, new MySqlCompiler());
            return _queryFactory;
        }
    }
}
