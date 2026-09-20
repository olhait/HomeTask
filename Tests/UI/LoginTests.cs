using Tests.Helpers;
using UI;
using UI.Pages;
using static Microsoft.Playwright.Assertions;

namespace Tests.UI;

public class LoginTests : UiBaseTest
{
    [Test]
    public async Task SuccessLoginTest()
    {
        string test = EnvConfig.Email;
        LoginPage loginPage = new LoginPage(Page);
        await Page.GotoAsync(BaseUrl+"accion-protegida/?route=/");
        await loginPage.Login(EnvConfig.Email, EnvConfig.Password);
        await Expect(loginPage.AccountTitle).ToBeVisibleAsync();
    }
}