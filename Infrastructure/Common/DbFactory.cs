using Infrastructure.Common.Interfaces;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace Infrastructure.Common
{
    public class DbFactory : IDbFactory, IDisposable
    {
        public IDbConnection Conn { get; }

        public IDbTransaction? Trans { get; set; }

        public DbFactory(IConfiguration config)
        {
            Conn = new MySqlConnection(config.GetConnectionString("DefaultConnection"));
            Conn.Open();
        }

        public void Dispose() => Conn?.Dispose();
    }
}
