using System.Text.Json.Serialization;

namespace API.ApiModels.Booking.Models;

public class ExpectedTotalPrice
{
    [JsonPropertyName("amount")]
    public decimal Amount { get; set; }

    [JsonPropertyName("currencyCode")]
    public string CurrencyCode { get; set; } = string.Empty;
}