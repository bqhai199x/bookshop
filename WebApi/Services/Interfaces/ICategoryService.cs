using Entities;
using Entities.ViewModel;

namespace WebApi.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAll(int pageIndex, int pageSize);

        Task<Category?> GetById(int id);

        Task<int> Add(CategoryRq.InsertDto categoryRq);

        Task<int> Delete(int id);

        Task<int> Update(CategoryRq.UpdateDto categoryRq);
    }
}
