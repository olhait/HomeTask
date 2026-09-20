using System.Text.Json.Serialization;

namespace API.ApiModels.Booking.Models;

public class VenueInfo
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("normalisedName")]
    public string NormalisedName { get; set; } = string.Empty;

    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;
}