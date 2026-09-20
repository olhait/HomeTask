using System.Text.Json.Serialization;

namespace API.ApiModels.Booking.Models;

public class CancellationPolicyInfo
{
    [JsonPropertyName("cancellationAllowed")]
    public bool CancellationAllowed { get; set; }

    [JsonPropertyName("rescheduleAllowed")]
    public bool RescheduleAllowed { get; set; }

    [JsonPropertyName("creditUntil")]
    public string CreditUntil { get; set; } = string.Empty;

    [JsonPropertyName("refundUntil")]
    public string RefundUntil { get; set; } = string.Empty;

    [JsonPropertyName("listOfReasonsTitle")]
    public string ListOfReasonsTitle { get; set; } = string.Empty;

    [JsonPropertyName("reschedulePeriodHours")]
    public int ReschedulePeriodHours { get; set; }

    [JsonPropertyName("reschedulePolicyPeriodHours")]
    public int ReschedulePolicyPeriodHours { get; set; }

    [JsonPropertyName("allowed")]
    public bool Allowed { get; set; }
}