using Entities;
using Entities.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
            List<Category> categoryList = await _categoryService.GetAll(pageIndex, pageSize);
            return Ok(categoryList);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Add(CategoryRq.InsertDto category)
        {
            int categoryId = await _categoryService.Add(category);
            return Ok(categoryId);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int result = await _categoryService.Delete(id);
            return Ok(result > 0);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Update(CategoryRq.UpdateDto category)
        {
            int result = await _categoryService.Update(category);
            return Ok(result > 0);
        }
    }
}