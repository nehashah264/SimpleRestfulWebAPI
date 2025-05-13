using Microsoft.AspNetCore.Mvc;
using SimpleRestfulWebAPI.Domain.Models;
using SimpleRestfulWebAPI.Services;

namespace SimpleRestfulWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Get Products 
        /// </summary>
        /// <param name="nameFilter"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>

        [HttpGet]
        public async Task<IActionResult> GetProducts(string? nameFilter, int page = 1, int pageSize = 10)
        {
            var products = await _productService.GetProductsAsync(nameFilter, page, pageSize);
            return Ok(products);
        }

        /// <summary>
        /// Add Product
        /// </summary>
        /// <param name="productDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductAddRequestDto productDto)
        {
            // Validate the model state
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _productService.AddProductAsync(productDto);
            return CreatedAtAction(nameof(GetProducts), new { id = product.Id }, product);
        }

        /// <summary>
        /// Update Product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="productDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(string id, [FromBody] ProductUpdateRequestDto productDto)
        {
            var product = await _productService.UpdateProductAsync(id, productDto);
            return Ok(product);
        }

        /// <summary>
        /// Delete Product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return NoContent();
        }
    }
}
