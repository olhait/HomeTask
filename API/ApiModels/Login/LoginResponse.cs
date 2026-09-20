using System.Text.Json.Serialization;
using API.ApiModels.Login.Models;

namespace API.ApiModels.Login;

public class LoginResponse
{
    [JsonPropertyName("authTokens")]
    public AuthTokens AuthTokens { get; set; } = new();

    [JsonPropertyName("accountId")]
    public int AccountId { get; set; }

    [JsonPropertyName("userTypePriorLogin")]
    public string UserTypePriorLogin { get; set; } = string.Empty;
}