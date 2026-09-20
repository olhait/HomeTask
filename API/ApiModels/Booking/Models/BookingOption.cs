using System.Text.Json.Serialization;

namespace API.ApiModels.Booking.Models;

public class BookingOption
{
    [JsonPropertyName("optionId")]
    public int OptionId { get; set; }
}