using Entities;

namespace WebApi.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategory();

        Task<Category?> GetCategoryById(int id);
    }
}
