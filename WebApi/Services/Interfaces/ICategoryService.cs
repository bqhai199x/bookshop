using Entities;

namespace WebApi.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAll();

        Task<Category?> GetById(int id);

        Task<int> Add(Category category);

        Task<int> Delete(int id);

        Task<int> Update(Category category);
    }
}
