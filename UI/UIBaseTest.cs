using Microsoft.Playwright;
namespace UI;

public class UiBaseTest
{
    protected IPage Page;
    protected string BaseUrl => "https://www.treatwell.es/";

    [SetUp]
    public async Task InitDriver()
    {
         var playwright = await Playwright.CreateAsync();
         var browser = await playwright.Chromium
            .LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });

        Page = await browser.NewPageAsync();
        await Page.GotoAsync(BaseUrl);
    }

    [TearDown]
    public async Task TearDownDriver()
    {
       await Page.CloseAsync();
    }
}