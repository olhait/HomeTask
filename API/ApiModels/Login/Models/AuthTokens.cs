using System.Text.Json.Serialization;

namespace API.ApiModels.Login.Models;

public class AuthTokens
{
    [JsonPropertyName("X-ITKT-TOKEN")]
    public string ItkToken { get; set; } = string.Empty;

    [JsonPropertyName("X-ATKT-TOKEN")]
    public string AtktToken { get; set; } = string.Empty;
}