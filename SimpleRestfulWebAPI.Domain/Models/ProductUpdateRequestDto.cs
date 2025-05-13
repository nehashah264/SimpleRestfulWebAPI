namespace SimpleRestfulWebAPI.Domain.Models
{
    public class ProductUpdateRequestDto
    {
        public string? Name { get; set; }

        public ProductDataDto? Data { get; set; }
    }
}
