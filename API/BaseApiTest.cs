using System.Text.Json;
using API.ApiModels.Login;
using API.Utils.API;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace API;

public class BaseApiTest : PlaywrightTest
{
    protected IAPIRequestContext Request { get; set; } = null!;

    protected string BaseUrl => "https://www.treatwell.es/";

    [SetUp]
    public async Task SetUpApiContext()
    {
        Request = await Playwright.APIRequest.NewContextAsync(new()
        {
            BaseURL = BaseUrl,
            ExtraHTTPHeaders = new Dictionary<string, string>
            {
                { "Accept", "application/json" }
            }
        });
    }

    [TearDown]
    public async Task TearDownApiContext()
    {
        await Request.DisposeAsync();
    }

    public async Task LoginViaApi(string email, string password)
    {
        ApiRequestExecutor apiRequestExecutor = new ApiRequestExecutor(Request);
        var loginUrl = $"{BaseUrl}api/v2/me/login";{}
    
        LoginRequest loginData = new LoginRequest
        {
            Email = email,
            Password = password,
            Cookies = true
        };
        
        var response = await apiRequestExecutor.SendPostRequest<LoginResponse>(loginUrl, loginData);
        
        apiRequestExecutor.ITKTToken = response?.AuthTokens.ItkToken;
        apiRequestExecutor.ATKTToken = response?.AuthTokens.AtktToken;
    }
}