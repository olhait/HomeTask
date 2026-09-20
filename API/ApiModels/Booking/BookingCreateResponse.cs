using System.Text.Json.Serialization;

namespace API.ApiModels.Booking;

public class BookingCreateResponse
{
    [JsonPropertyName("nextActionType")]
    public string NextActionType { get; set; } = string.Empty;

    [JsonPropertyName("orderToken")]
    public string OrderToken { get; set; } = string.Empty;
}