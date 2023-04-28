using Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services.Interfaces;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAll()
        {
            List<Product> products = await _productService.GetAllProduct();
            return Ok(products);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id)
        {
            Product? product = await _productService.GetProductById(id);
            return Ok(product);
        }
    }
}