using SimpleRestfulWebAPI.Domain.Models;

namespace SimpleRestfulWebAPI.Api
{
    public interface IRestfulApi
    {
        Task<IEnumerable<ProductDto>> GetProductsAsync(string? nameFilter, int page, int pageSize);
        Task<ProductDto> AddProductAsync(ProductAddRequestDto productDto);
        Task<ProductDto> UpdateProductAsync(string id, ProductUpdateRequestDto productDto);
        Task DeleteProductAsync(string id);
    }
}
