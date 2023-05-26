using Entities;
using Microsoft.AspNetCore.Mvc;
using Utilities;
using WebApi.Services.Interfaces;

namespace WebApi.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Category? category = await _categoryService.GetById(id);
            return Ok(category);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int pageIndex, int pageSize)
        {
            PaginatedList <Category> categoryList = await _categoryService.GetAll(pageIndex, pageSize);
            return Ok(categoryList);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Category category)
        {
            int categoryId = await _categoryService.Add(category);
            return Ok(categoryId);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int result = await _categoryService.Delete(id);
            return Ok(result > 0);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Category category)
        {
            int result = await _categoryService.Update(category);
            return Ok(result > 0);
        }
    }
}