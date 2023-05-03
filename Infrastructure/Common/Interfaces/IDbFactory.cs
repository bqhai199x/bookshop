using SqlKata.Execution;
using System.Data;

namespace Infrastructure.Common.Interfaces
{
    public interface IDbFactory
    {
        IDbConnection Connection { get; }

        IDbTransaction? Transaction { get; set; }
    }
}
