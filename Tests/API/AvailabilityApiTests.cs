using System.Web;
using API;
using API.ApiModels.Availability;
using API.Utils.API;
using Tests.Helpers;

namespace Tests.API;

public class AvailabilityApiTests : BaseApiTest
{
    private const string AvailabilityUrl = "/datetime-ui/api/availability";
    
    private const int VenueId = 543672;
    private const string MenuItemId = "TR7490626";
    private const int OptionId = 14227255;
    private static string TestDate = DateHelpers.TodayOrNextWeekday;

    private static string BuildAvailabilityUrl(
        int venueId, 
        string menuItemId, 
        int optionId, 
        string startDate, 
        string endDate)
    {
        var services = $@"[{{""menuItemId"":""{menuItemId}"",""optionIds"":[""{optionId}""]}}]";
        var query = HttpUtility.ParseQueryString(string.Empty);
        query["venueId"] = venueId.ToString();
        query["proposedServices"] = services;
        query["startDate"] = startDate;
        query["endDate"] = endDate;
        return $"{AvailabilityUrl}?{query}";
    }
    
    [Test]
    public async Task GetAvailabilityDateTime()
    {
        ApiRequestExecutor apiRequestExecutor = new ApiRequestExecutor(Request);
        
        var availabilityResponse = await apiRequestExecutor.SendGetRequest<AvailabilityResponse>(BuildAvailabilityUrl(VenueId, MenuItemId, OptionId, TestDate, TestDate));
 
        Assert.Multiple(() =>
        {
            Assert.That(availabilityResponse.Days.First().Value.Date, Is.EqualTo(TestDate));
            Assert.That(availabilityResponse.Days.First().Value.Times.First().FullPriceAmount.Replace(' ', ' '), Is.EqualTo("3 €"));
        });    
    }
}