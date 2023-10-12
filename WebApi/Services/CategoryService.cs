using AutoMapper;
using Entities;
using Entities.ViewModel;
using Infrastructure.Common.Interfaces;
using SqlKata;
using WebApi.Services.Interfaces;

namespace WebApi.Services
{
    public class CategoryService : BaseService, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<int> Add(CategoryRq.InsertDto categoryRq)
        {
            var category = _mapper.Map<Category>(categoryRq);
            int id = await _unitOfWork.Category.Add(category);
            return id;
        }

        public async Task<int> Delete(int id)
        {
            int result = await _unitOfWork.Category.DeleteById(id);
            return result;
        }

        public async Task<List<Category>> GetAll(int pageIndex, int pageSize)
        {
            Query query = _unitOfWork.Category.GetTableQuery().Skip((pageIndex - 1) * pageSize).Take(pageSize);
            List<Category> categoryList = await _unitOfWork.Category.Filter(query);
            return categoryList;
        }

        public async Task<Category?> GetById(int id)
        {
            Category? category = await _unitOfWork.Category.FindById(id);
            return category;
        }

        public async Task<int> Update(CategoryRq.UpdateDto categoryRq)
        {
            var category = _mapper.Map<Category>(categoryRq);
            int result = await _unitOfWork.Category.Update(category);
            return result;
        }
    }
}
