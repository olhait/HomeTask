using System.Text.Json.Serialization;

namespace API.ApiModels.Booking.Models;

public class BookingItem
{
    [JsonPropertyName("offerId")]
    public int OfferId { get; set; }

    [JsonPropertyName("options")]
    public List<BookingOption> Options { get; set; } = [];

    [JsonPropertyName("fulfillment")]
    public string Fulfillment { get; set; } = string.Empty;
}