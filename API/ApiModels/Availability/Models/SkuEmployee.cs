using System.Text.Json.Serialization;

namespace API.ApiModels.Availability.Models;

public class SkuEmployee
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("employeeName")]
    public string EmployeeName { get; set; } = string.Empty;
}
