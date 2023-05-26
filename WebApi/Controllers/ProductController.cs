using Entities;
using Microsoft.AspNetCore.Mvc;
using Utilities;
using WebApi.Services.Interfaces;

namespace WebApi.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int pageIndex, int pageSize)
        {
            PaginatedList<Product> products = await _productService.GetAll(pageIndex, pageSize);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Product? product = await _productService.GetById(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Product product)
        {
            int categoryId = await _productService.Add(product);
            return Ok(categoryId);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int result = await _productService.Delete(id);
            return Ok(result > 0);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Product product)
        {
            int result = await _productService.Update(product);
            return Ok(result > 0);
        }
    }
}