using System.ComponentModel.DataAnnotations;

namespace SimpleRestfulWebAPI.Domain.Models
{
    public class ProductAddRequestDto
    {
        [Required(ErrorMessage = "Product Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Product Data is required.")]
        public ProductDataDto Data { get; set; }
    }
}
