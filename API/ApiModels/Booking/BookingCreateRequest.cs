using System.Text.Json.Serialization;
using API.ApiModels.Booking.Models;

namespace API.ApiModels.Booking;

public class BookingCreateRequest
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty;

    [JsonPropertyName("telephone")]
    public string Telephone { get; set; } = string.Empty;

    [JsonPropertyName("paymentMethod")]
    public string PaymentMethod { get; set; } = string.Empty;

    [JsonPropertyName("expectedTotalPrice")]
    public ExpectedTotalPrice ExpectedTotalPrice { get; set; } = new();

    [JsonPropertyName("allowMarketing")]
    public AllowMarketing AllowMarketing { get; set; } = new();

    [JsonPropertyName("date")]
    public string Date { get; set; } = string.Empty;

    [JsonPropertyName("time")]
    public int Time { get; set; }

    [JsonPropertyName("items")]
    public List<BookingItem> Items { get; set; } = [];

    [JsonPropertyName("venueId")]
    public int VenueId { get; set; }

    [JsonPropertyName("appointmentNotes")]
    public string AppointmentNotes { get; set; } = string.Empty;
}