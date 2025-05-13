using SimpleRestfulWebAPI.Api;
using SimpleRestfulWebAPI.Caching;
using SimpleRestfulWebAPI.Domain.Models;

namespace SimpleRestfulWebAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IRestfulApi _restfulApi;
        private readonly ICachingService _cachingService;

        public ProductService(IRestfulApi restfulApi, ICachingService cachingServices)
        {
            _restfulApi = restfulApi;
            _cachingService = cachingServices;
        }

        /// <summary>
        /// Get Products with Distributed Caching Using Redis
        /// </summary>
        /// <param name="nameFilter"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ProductDto>> GetProductsAsync(string? nameFilter, int page, int pageSize)
        {
            const string cacheKey = "products";

            var products = await _cachingService.GetAsync(cacheKey, async () =>
            {
                return await _restfulApi.GetProductsAsync(nameFilter, page, pageSize);
            }, TimeSpan.FromMinutes(180), forceFetch: false);

            var filtered = products?
               .Where(p => string.IsNullOrEmpty(nameFilter) || p.Name.Contains(nameFilter, StringComparison.OrdinalIgnoreCase))
               .Skip((page - 1) * pageSize)
               .Take(pageSize);
            return filtered ?? Enumerable.Empty<ProductDto>();
        }

        /// <summary>
        /// Add Product and Reset Caching
        /// </summary>
        /// <param name="productDto"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<ProductDto> AddProductAsync(ProductAddRequestDto productDto)
        {
            if (await ValidateIfProductNameExists(productDto.Name))
            {
                throw new InvalidOperationException($"Product with name {productDto.Name} already exists.");
            }

            var product = await _restfulApi.AddProductAsync(productDto);
            await _cachingService.RemoveAsync("products");

            return product;
        }

        private async Task<bool> ValidateIfProductNameExists(string name)
        {
            var products = await GetProductsAsync(null, 1, 1000);
            return products.Any(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Delete Product By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteProductAsync(string id)
        {
            await _restfulApi.DeleteProductAsync(id);
            await _cachingService.RemoveAsync("products");
        }

        /// <summary>
        /// Update Product Details
        /// </summary>
        /// <param name="id"></param>
        /// <param name="productDto"></param>
        /// <returns></returns>
        public async Task<ProductDto> UpdateProductAsync(string id, ProductUpdateRequestDto productDto)
        {
            var updatedProduct = await _restfulApi.UpdateProductAsync(id, productDto);
            await _cachingService.RemoveAsync("products");
            return updatedProduct;
        }
    }
}
