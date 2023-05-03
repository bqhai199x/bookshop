using Infrastructure.Common.Interfaces;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace Infrastructure.Common
{
    public class DbFactory : IDbFactory, IDisposable
    {
        public IDbConnection Connection { get; }

        public IDbTransaction? Transaction { get; set; }

        public DbFactory(IConfiguration config)
        {
            Connection = new MySqlConnection(config.GetConnectionString("DefaultConnection"));
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }
}
