using System.Text.Json.Serialization;

namespace API.ApiModels.Availability.Models;

public class Sku
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("durationMinutes")]
    public int DurationMinutes { get; set; }

    [JsonPropertyName("durationMinutesFormatted")]
    public string DurationMinutesFormatted { get; set; } = string.Empty;

    [JsonPropertyName("employees")]
    public List<SkuEmployee> Employees { get; set; } = [];
}