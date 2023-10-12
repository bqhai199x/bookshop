using Entities;
using Infrastructure.Common.Interfaces;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IImageRepository : IGenericRepository<Image>
    {
        Task<int> Add(ImageType imageType, int typeId, params string[] urls);

        Task<int> DeleteTypeId(ImageType type, int typeId);
    }
}
