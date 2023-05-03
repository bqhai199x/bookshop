using Entities;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IImageRepository
    {
        Task<int> Add(ImageType imageType, int typeId, params string[] urls);

        Task<int> DeleteById(params int[] ids);

        Task<int> DeleteTypeId(ImageType type, int typeId);
    }
}
