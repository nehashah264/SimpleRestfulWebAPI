
using System.Text.Json.Serialization;

namespace SimpleRestfulWebAPI.Domain.Models
{
    [JsonConverter(typeof(ProductDataConverter))]
    public class ProductDataDto
    {
        public string? Color { get; set; }
        public string? StrapColour { get; set; }
        public string? Capacity { get; set; }
        public string? CapacityGB { get; set; }
        public double? Price { get; set; }
        public string? Generation { get; set; }
        public string? Description { get; set; }
        public string? CPUModel { get; set; }
        public string? HardDiskSize { get; set; }
        public int? Year { get; set; }
        public double? ScreenSize { get; set; }
        public string? CaseSize { get; set; }
    }
}
