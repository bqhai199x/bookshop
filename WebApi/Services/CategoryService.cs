using Entities;
using Infrastructure.Common.Interfaces;
using WebApi.Services.Interfaces;

namespace WebApi.Services
{
    public class CategoryService : BaseService, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<List<Category>> GetAllCategory()
        {
            List<Category> categoryList = await _unitOfWork.Category.GetAllAsync();
            return categoryList;
        }

        public async Task<Category?> GetCategoryById(int id)
        {
            Category? category = await _unitOfWork.Category.GetByIdAsync(id);
            return category;
        }
    }
}
