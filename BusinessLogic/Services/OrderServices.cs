using BusinessLogic.BaseServices;
using DataAccess.Infrastructure;
using DataAccess.Repositories;
using Entities;

namespace BusinessLogic.Services
{
    public class OrderServices : BaseServices<Order>, IOrderServices
    {
        public OrderServices(IUnitOfWork unitOfWork, IGenericRepository<Order> genericRepository) : base(unitOfWork, genericRepository) { }
    }
}
