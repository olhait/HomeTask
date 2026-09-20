using System.Text.Json.Serialization;

namespace API.ApiModels.Availability.Models;

public class Service
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("skuIds")]
    public List<string> SkuIds { get; set; } = [];
}