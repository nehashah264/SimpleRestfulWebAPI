using SimpleRestfulWebAPI.Domain.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SimpleRestfulWebAPI.Domain;

public class ProductDataConverter : JsonConverter<ProductDataDto>
{
    public override ProductDataDto Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        var root = document.RootElement;

        var data = new ProductDataDto();

        foreach (var property in root.EnumerateObject())
        {
            string name = property.Name.ToLowerInvariant();

            switch (name)
            {
                case "color":
                    data.Color = property.Value.ToString();
                    break;

                case "strap colour":
                    data.StrapColour = property.Value.ToString();
                    break;

                case "capacity":
                    data.Capacity = property.Value.ToString();
                    break;

                case "capacity gb":
                    data.CapacityGB = property.Value.ToString();
                    break;

                case "price":
                    if (property.Value.ValueKind == JsonValueKind.String && double.TryParse(property.Value.ToString(), out var parsed))
                        data.Price = parsed;
                    else if (property.Value.ValueKind == JsonValueKind.Number)
                        data.Price = property.Value.GetDouble();
                    break;

                case "generation":
                    data.Generation = property.Value.ToString();
                    break;

                case "description":
                    data.Description = property.Value.ToString();
                    break;

                case "cpu model":
                    data.CPUModel = property.Value.ToString();
                    break;

                case "hard disk size":
                    data.HardDiskSize = property.Value.ToString();
                    break;

                case "year":
                    if (property.Value.TryGetInt32(out int year))
                        data.Year = year;
                    break;

                case "screen size":
                    if (property.Value.TryGetDouble(out double screen))
                        data.ScreenSize = screen;
                    break;

                case "case size":
                    data.CaseSize = property.Value.ToString();
                    break;
                default:
                    break;
            }
        }

        return data;
    }

    public override void Write(Utf8JsonWriter writer, ProductDataDto value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        if (!string.IsNullOrEmpty(value.Color)) writer.WriteString("color", value.Color);
        if (!string.IsNullOrEmpty(value.StrapColour)) writer.WriteString("Strap Colour", value.StrapColour);
        if (!string.IsNullOrEmpty(value.Capacity)) writer.WriteString("capacity", value.Capacity);
        if (!string.IsNullOrEmpty(value.CapacityGB)) writer.WriteString("capacity GB", value.CapacityGB);
        if (value.Price.HasValue) writer.WriteNumber("price", value.Price.Value);
        if (!string.IsNullOrEmpty(value.Generation)) writer.WriteString("generation", value.Generation);
        if (!string.IsNullOrEmpty(value.Description)) writer.WriteString("Description", value.Description);
        if (!string.IsNullOrEmpty(value.CPUModel)) writer.WriteString("CPU model", value.CPUModel);
        if (!string.IsNullOrEmpty(value.HardDiskSize)) writer.WriteString("Hard disk size", value.HardDiskSize);
        if (value.Year.HasValue) writer.WriteNumber("year", value.Year.Value);
        if (value.ScreenSize.HasValue) writer.WriteNumber("Screen size", value.ScreenSize.Value);
        if (!string.IsNullOrEmpty(value.CaseSize)) writer.WriteString("Case Size", value.CaseSize);

        writer.WriteEndObject();
    }
}
