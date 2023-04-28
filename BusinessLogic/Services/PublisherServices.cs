using BusinessLogic.BaseServices;
using DataAccess.Infrastructure;
using DataAccess.Repositories;
using Entities;

namespace BusinessLogic.Services
{
    public class PublisherServices : BaseServices<Publisher>, IPublisherServices
    {
        public PublisherServices(IUnitOfWork unitOfWork, IGenericRepository<Publisher> genericRepository) : base(unitOfWork, genericRepository) { }
    }
}
