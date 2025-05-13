using SimpleRestfulWebAPI.Domain.Models;
using System.Net.Http.Json;

namespace SimpleRestfulWebAPI.Api
{
    public class RestfulApi : IRestfulApi
    {
        private readonly HttpClient _httpClient;

        public RestfulApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Add Product
        /// </summary>
        /// <param name="productDto"></param>
        /// <returns></returns>
        public async Task<ProductDto> AddProductAsync(ProductAddRequestDto productDto)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_httpClient.BaseAddress}/objects", productDto);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<ProductDto>();
        }

        /// <summary>
        /// Delete Product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteProductAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"{_httpClient.BaseAddress}/objects/{id}");
            response.EnsureSuccessStatusCode();
        }

        /// <summary>
        /// Get Products
        /// </summary>
        /// <param name="nameFilter"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ProductDto>> GetProductsAsync(string? nameFilter, int page, int pageSize)
        {
            return await _httpClient.GetFromJsonAsync<List<ProductDto>>($"{_httpClient.BaseAddress}/objects");
        }

        /// <summary>
        /// Update Product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="productDto"></param>
        /// <returns></returns>
        public async Task<ProductDto> UpdateProductAsync(string id, ProductUpdateRequestDto productDto)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_httpClient.BaseAddress}/objects/{id}", productDto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ProductDto>();
        }
    }
}
