using System.Text.Json.Serialization;
using API.ApiModels.Booking.Models;

namespace API.ApiRequestExecutors.Booking;

public class BookingCancelResponse
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("reference")]
    public string Reference { get; set; } = string.Empty;

    [JsonPropertyName("createdAt")]
    public string CreatedAt { get; set; } = string.Empty;

    [JsonPropertyName("customer")]
    public CustomerInfo Customer { get; set; } = new();

    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;

    [JsonPropertyName("totalPrice")]
    public string TotalPrice { get; set; } = string.Empty;

    [JsonPropertyName("discounts")]
    public List<object> Discounts { get; set; } = [];

    [JsonPropertyName("payments")]
    public List<object> Payments { get; set; } = [];

    [JsonPropertyName("payAtVenue")]
    public string PayAtVenue { get; set; } = string.Empty;

    [JsonPropertyName("isPayAtVenue")]
    public bool IsPayAtVenue { get; set; }

    [JsonPropertyName("cancellationPolicy")]
    public CancellationPolicyInfo CancellationPolicy { get; set; } = new();

    [JsonPropertyName("channelType")]
    public string ChannelType { get; set; } = string.Empty;

    [JsonPropertyName("reviewable")]
    public bool Reviewable { get; set; }

    [JsonPropertyName("refund")]
    public RefundInfo Refund { get; set; } = new();

    [JsonPropertyName("paymentProtected")]
    public bool PaymentProtected { get; set; }
}