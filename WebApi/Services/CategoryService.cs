using Entities;
using Infrastructure.Common.Interfaces;
using Utilities;
using WebApi.Base;
using WebApi.Services.Interfaces;
using static Dapper.SqlMapper;

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

        public async Task<PaginatedList<Category>> GetAll(int pageIndex, int pageSize)
        {
            int total = await _unitOfWork.Category.Count();
            int totalPages = (int)Math.Ceiling(total / (double)pageSize);
            if (pageIndex > totalPages || pageIndex < 1) pageIndex = 1;
            List<Category> categoryList = await _unitOfWork.Category.GetAll(pageIndex, pageSize);
            if(categoryList.Count == 0)
            {
                throw new NoDataException();
            }
            var result = new PaginatedList<Category>(categoryList, total, pageIndex, pageSize);
            return result;
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
