using SimpleRestfulWebAPI.Domain.Models;

namespace SimpleRestfulWebAPI.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProductsAsync(string? nameFilter, int page, int pageSize);
        Task<ProductDto> AddProductAsync(ProductAddRequestDto productDto);
        Task<ProductDto> UpdateProductAsync(string id, ProductUpdateRequestDto productDto);
        Task DeleteProductAsync(string id);
    }
}
