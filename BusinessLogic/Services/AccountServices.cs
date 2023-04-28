using BusinessLogic.BaseServices;
using DataAccess.Infrastructure;
using DataAccess.Repositories;
using Entities;

namespace BusinessLogic.Services
{
    public class AccountServices : BaseServices<Account>, IAccountServices
    {
        public AccountServices(IUnitOfWork unitOfWork, IGenericRepository<Account> genericRepository) : base(unitOfWork, genericRepository) { }
    }
}
