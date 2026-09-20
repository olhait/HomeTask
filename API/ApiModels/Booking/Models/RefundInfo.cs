using System.Text.Json.Serialization;

namespace API.ApiModels.Booking.Models;

public class RefundInfo
{
    [JsonPropertyName("items")]
    public List<object> Items { get; set; } = [];

    [JsonPropertyName("totalRefund")]
    public string TotalRefund { get; set; } = string.Empty;
}