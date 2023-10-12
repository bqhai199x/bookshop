using AutoMapper;
using Entities;
using Infrastructure.Common.Interfaces;
using SqlKata;
using WebApi.Services.Interfaces;

namespace WebApi.Services
{
    public class AccountService : BaseService, IAccountService
    {
        public AccountService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Account?> GetByUserName(string userName)
        {
            Query query = _unitOfWork.Account.GetTableQuery().Where("UserName", userName);
            Account? account = await _unitOfWork.Account.Find(query);
            return account;
        }
    }
}
