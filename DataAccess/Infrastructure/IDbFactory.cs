using DataAccess.Data;

namespace DataAccess.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        BookStoreContext Init();
    }
}
