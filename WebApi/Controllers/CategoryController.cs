using Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services.Interfaces;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id)
        {
            Category? category = await _categoryService.GetCategoryById(id);
            return Ok(category);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAll()
        {
            List<Category> categoryList = await _categoryService.GetAllCategory();
            return Ok(categoryList);
        }
    }
}