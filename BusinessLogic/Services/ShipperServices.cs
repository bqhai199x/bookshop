using BusinessLogic.BaseServices;
using DataAccess.Infrastructure;
using DataAccess.Repositories;
using Entities;

namespace BusinessLogic.Services
{
    public class ShipperServices : BaseServices<Shipper>, IShipperServices
    {
        public ShipperServices(IUnitOfWork unitOfWork, IGenericRepository<Shipper> genericRepository) : base(unitOfWork, genericRepository) { }
    }
}
