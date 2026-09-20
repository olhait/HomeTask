using System.Text.Json.Serialization;

namespace API.ApiModels.Login;

public class LoginRequest
{
    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty;

    [JsonPropertyName("password")]
    public string Password { get; set; } = string.Empty;

    [JsonPropertyName("cookies")]
    public bool Cookies { get; set; } = true;
}