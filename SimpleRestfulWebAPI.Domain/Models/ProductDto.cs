namespace SimpleRestfulWebAPI.Domain.Models
{
    public class ProductDto
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public ProductDataDto? Data { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
