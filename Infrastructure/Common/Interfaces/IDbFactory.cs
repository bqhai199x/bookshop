using SqlKata.Execution;
using System.Data;

namespace Infrastructure.Common.Interfaces
{
    public interface IDbFactory
    {
        IDbConnection Conn { get; }

        IDbTransaction? Trans { get; set; }
    }
}
