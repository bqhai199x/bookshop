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

        public async Task<int> Add(Category category)
        {
            int id = await _unitOfWork.Category.Add(category);
            return id;
        }

        public async Task<int> Delete(int id)
        {
            int result = await _unitOfWork.Category.Delete(id);
            return result;
        }

        public async Task<List<Category>> GetAll()
        {
            List<Category> categoryList = await _unitOfWork.Category.GetAll();
            return categoryList;
        }

        public async Task<Category?> GetById(int id)
        {
            Category? category = await _unitOfWork.Category.GetById(id);
            return category;
        }

        public async Task<int> Update(Category category)
        {
            int result = await _unitOfWork.Category.Update(category);
            return result;
        }
    }
}
