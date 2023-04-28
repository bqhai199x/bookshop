using Entities;
using Infrastructure.Common;
using Infrastructure.Common.Interfaces;
using Infrastructure.Repositories.Interfaces;

namespace Infrastructure.Repositories
{
    internal class ImageRepository : BaseRepository, IImageRepository
    {
        public ImageRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public Task<int> AddAsync(Image entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Image>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Image?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Image entity)
        {
            throw new NotImplementedException();
        }
    }
}
