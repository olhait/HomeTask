using System.Text.Json.Serialization;

namespace API.ApiModels.Availability.Models;

public class Day
{
    [JsonPropertyName("date")]
    public string Date { get; set; } = string.Empty;

    [JsonPropertyName("dayNumber")]
    public string DayNumber { get; set; } = string.Empty;

    [JsonPropertyName("dayName")]
    public string DayName { get; set; } = string.Empty;

    [JsonPropertyName("isAvailable")]
    public bool IsAvailable { get; set; }

    [JsonPropertyName("times")]
    public List<TimeSlot> Times { get; set; } = [];
}