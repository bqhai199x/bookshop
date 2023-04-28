using BusinessLogic.BaseServices;
using DataAccess.Infrastructure;
using DataAccess.Repositories;
using Entities;

namespace BusinessLogic.Services
{
    public class CouponServices : BaseServices<Coupon>, ICouponServices
    {
        public CouponServices(IUnitOfWork unitOfWork, IGenericRepository<Coupon> genericRepository) : base(unitOfWork, genericRepository) { }
    }
}
