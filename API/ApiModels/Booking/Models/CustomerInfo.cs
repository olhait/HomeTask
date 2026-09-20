using System.Text.Json.Serialization;

namespace API.ApiModels.Booking.Models;

public class CustomerInfo
{
    [JsonPropertyName("accountId")]
    public int AccountId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty;

    [JsonPropertyName("phone")]
    public string Phone { get; set; } = string.Empty;

    [JsonPropertyName("newsletterSignup")]
    public bool NewsletterSignup { get; set; }
}