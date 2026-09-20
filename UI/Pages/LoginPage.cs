using Microsoft.Playwright;

namespace UI.Pages;

public class LoginPage 
{
    private readonly IPage _page;
    
    public LoginPage(IPage page)
    {
        _page = page;
    }
    
    public ILocator CookieBanner => _page.Locator("[id='onetrust-banner-sdk']");
    public ILocator AcceptAllCookiesButton => _page.Locator("[id='onetrust-accept-btn-handler']");
    public ILocator EmailField=> _page.Locator("[class='persistent-field login-email']");
    public ILocator PasswordField=> _page.Locator("[class='login-psswd']");
    public ILocator AccountTitle => _page.Locator("[href='/account/']");
    public ILocator LoginButton => _page.Locator("[data-id='email-login']");

    public async Task Login(string email, string password)
    {
        if (CookieBanner.IsVisibleAsync() != null)
        {
            await AcceptAllCookiesButton.ClickAsync();
        }
        await EmailField.FillAsync(email);
        await PasswordField.FillAsync(password);
        await LoginButton.ClickAsync();
    }
}