using System.Text.Json.Serialization;

namespace API.ApiModels.Booking;

public class BookingCancellationRequest
{
    [JsonPropertyName("reasonCode")]
    public string ReasonCode { get; set; } = string.Empty;
}

