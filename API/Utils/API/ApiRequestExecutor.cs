using System.Text.Json;
using Microsoft.Playwright;

namespace API.Utils.API;

public class ApiRequestExecutor
{
    private IAPIRequestContext _request;
    
    public ApiRequestExecutor(IAPIRequestContext request)
    {
        _request = request;
    }
    
    public string? ITKTToken { get; set; } = null!;
    public string? ATKTToken { get; set; } = null!;
    
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = true  
    };

    public async Task<T?> SendGetRequest<T>(string endpoint, int expectedStatus=200)
    {
        IAPIResponse response  = await _request.GetAsync(endpoint);
        
        Assert.That(response.Status, Is.EqualTo(expectedStatus), "Check status code");
        
        var json = await response.TextAsync();
        return JsonSerializer.Deserialize<T>(json, JsonOptions);
    }
    
    public async Task<T?> SendPostRequest<T>(string endpoint, object payload, int expectedStatus=200)
    {
        Dictionary<string, string> headers = new();
        if (!string.IsNullOrWhiteSpace(ITKTToken))
        {
            headers.Add("x-csrf-token",ITKTToken);
        }
        
        APIRequestContextOptions requestOptions = new APIRequestContextOptions
        {
            DataObject = JsonSerializer.Serialize(payload, JsonOptions),
            Headers = headers
        };
        IAPIResponse response = await _request.PostAsync(endpoint, requestOptions);
        
        Assert.That(response.Status, Is.EqualTo(expectedStatus), "Check status code");
        
        var json = await response.TextAsync();
        return JsonSerializer.Deserialize<T>(json, JsonOptions);
    }
}