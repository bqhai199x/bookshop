using Entities;

namespace WebApi.Services.Interfaces
{
    public interface IAccountService
    {
        Task<Account?> GetByUserName(string userName);
    }
}
