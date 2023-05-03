using Infrastructure.Common.Interfaces;
using WebApi.Services.Interfaces;

namespace WebApi.Services
{
    public class ImageService : BaseService, IImageService
    {
        public ImageService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
