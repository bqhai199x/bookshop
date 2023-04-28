using BusinessLogic.BaseServices;
using DataAccess.Infrastructure;
using DataAccess.Repositories;
using Entities;

namespace BusinessLogic.Services
{
    public class OrderDetailServices : BaseServices<OrderDetail>, IOrderDetailServices
    {
        public OrderDetailServices(IUnitOfWork unitOfWork, IGenericRepository<OrderDetail> genericRepository) : base(unitOfWork, genericRepository) { }
    }
}
