using System.Text.Json.Serialization;

namespace API.ApiModels.Booking.Models;

public class CancellationOrderItem
{
    [JsonPropertyName("itemId")]
    public long ItemId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;

    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }

    [JsonPropertyName("price")]
    public string Price { get; set; } = string.Empty;

    [JsonPropertyName("totalPrice")]
    public string TotalPrice { get; set; } = string.Empty;
}