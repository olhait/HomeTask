using System.Text.Json.Serialization;

namespace API.ApiModels.Booking.Models;

public class AllowMarketing
{
    [JsonPropertyName("treatwell")]
    public bool Treatwell { get; set; }

    [JsonPropertyName("venue")]
    public bool Venue { get; set; }
}