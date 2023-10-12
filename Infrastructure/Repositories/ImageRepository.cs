using Entities;
using Infrastructure.Common;
using Infrastructure.Common.Interfaces;
using Infrastructure.Repositories.Interfaces;
using SqlKata.Execution;

namespace Infrastructure.Repositories
{
    internal class ImageRepository : GenericRepository<Image>, IImageRepository
    {
        public ImageRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public async Task<int> Add(ImageType imageType, int typeId, params string[] urls)
        {
            var cols = new[] { "Type", "TypeId", "ImageURL" };
            var data = urls.Select(x => new object[]
            {
                (int) imageType, typeId, x
            });
            int result = await TableQuery.InsertAsync(cols, data);
            return result;
        }

        public async Task<int> DeleteTypeId(ImageType type, int typeId)
        {
            int result = await TableQuery
                .Where("Type", (int) type)
                .Where("TypeId", typeId)
                .DeleteAsync(DbTrans);
            return result;
        }
    }
}
