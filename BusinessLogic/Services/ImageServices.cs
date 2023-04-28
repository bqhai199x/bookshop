using BusinessLogic.BaseServices;
using DataAccess.Infrastructure;
using DataAccess.Repositories;
using Entities;

namespace BusinessLogic.Services
{
    public class ImageServices : BaseServices<Image>, IImageServices
    {
        public ImageServices(IUnitOfWork unitOfWork, IGenericRepository<Image> genericRepository) : base(unitOfWork, genericRepository) { }

    }
}
