using System.Text.Json.Serialization;

namespace API.ApiModels.Availability.Models;

public class TimeSlot
{
    [JsonPropertyName("startTime")]
    public string StartTime { get; set; } = string.Empty;

    [JsonPropertyName("employeeIds")]
    public List<int> EmployeeIds { get; set; } = [];

    [JsonPropertyName("discountPercentage")]
    public int DiscountPercentage { get; set; }

    [JsonPropertyName("salePriceAmount")]
    public string SalePriceAmount { get; set; } = string.Empty;

    [JsonPropertyName("fullPriceAmount")]
    public string FullPriceAmount { get; set; } = string.Empty;

    [JsonPropertyName("savingAmount")]
    public string SavingAmount { get; set; } = string.Empty;
}