using System.Text.Json.Serialization;

namespace API.ApiModels.Availability.Models;

public class Employee
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("portfolioImages")]
    public List<object> PortfolioImages { get; set; } = [];

    [JsonPropertyName("portfolioSentiments")]
    public List<object> PortfolioSentiments { get; set; } = [];

    [JsonPropertyName("treatmentCategoryGroups")]
    public List<object> TreatmentCategoryGroups { get; set; } = [];
}