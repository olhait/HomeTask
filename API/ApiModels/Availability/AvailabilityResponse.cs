using System.Text.Json.Serialization;
using API.ApiModels.Availability.Models;

namespace API.ApiModels.Availability;

public class AvailabilityResponse
{
    [JsonPropertyName("employees")]
    public Dictionary<string, Employee> Employees { get; set; } = [];

    [JsonPropertyName("days")]
    public Dictionary<string, Day> Days { get; set; } = [];

    [JsonPropertyName("firstIncludedDate")]
    public string FirstIncludedDate { get; set; } = string.Empty;

    [JsonPropertyName("lastIncludedDate")]
    public string LastIncludedDate { get; set; } = string.Empty;

    [JsonPropertyName("moreDaysInThePast")]
    public bool MoreDaysInThePast { get; set; }

    [JsonPropertyName("moreDaysInTheFuture")]
    public bool MoreDaysInTheFuture { get; set; }

    [JsonPropertyName("multiStaffSelectionExperimentEnabled")]
    public bool MultiStaffSelectionExperimentEnabled { get; set; }

    [JsonPropertyName("employeeSelectionAllowed")]
    public bool EmployeeSelectionAllowed { get; set; }

    [JsonPropertyName("skus")]
    public Dictionary<string, Sku> Skus { get; set; } = [];

    [JsonPropertyName("services")]
    public List<Service> Services { get; set; } = [];
}