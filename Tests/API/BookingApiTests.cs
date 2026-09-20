using API;
using API.Utils.API;
using Tests.Helpers;
using System.Text.Json;
using API.ApiModels.Booking;
using API.ApiModels.Booking.Models;
using Microsoft.Playwright;

namespace Tests.API;

public class BookingApiTests : BaseApiTest
{
    private const string BookingUrl = "checkout-api/order";
    
    private const int VenueId = 543672;
    private const int OfferId = 7490626;
    private const int OptionId = 14227255;
    
    private BookingCreateRequest DefaultBookingRequest() => new()
    {
        Name               = "Olha Mi",
        Email              = EnvConfig.Email,
        Telephone          = "+380666374287",
        PaymentMethod      = "PAY_AT_VENUE",
        ExpectedTotalPrice = new ExpectedTotalPrice { Amount = 3, CurrencyCode = "EUR" },
        AllowMarketing     = new AllowMarketing { Treatwell = false, Venue = false },
        Date               = DateHelpers.TodayOrNextWeekday,
        Time               = 540,
        Items              =
        [
            new BookingItem
            {
                OfferId     = OfferId,
                Fulfillment = "APPOINTMENT",
                Options     = [new BookingOption { OptionId = OptionId }]
            }
        ],
        VenueId            = VenueId,
        AppointmentNotes   = ""
    };

    [Test]
    public async Task CreateNewBooking()
    {
        ApiRequestExecutor apiRequestExecutor = new ApiRequestExecutor(Request);

        await LoginViaApi(EnvConfig.Email, EnvConfig.Password);
        
        var bookingResponse = await apiRequestExecutor.SendPostRequest<BookingCreateResponse>(BaseUrl+BookingUrl, DefaultBookingRequest());
        
        Assert.Multiple(() =>
        {
            Assert.That(bookingResponse.NextActionType,Is.EqualTo("SHOW_ORDER_CONFIRMATION"), "New Order successfully created");
            Assert.That(bookingResponse.OrderToken, Does.Match(@"^oT\d+\.[A-Za-z0-9]+\.[A-Za-z0-9]+$"), "Order Token is valid");
        }); 
    }
    
    [Test]
    public async Task CreateNewBooking_RaceCondition_OnlyOneRequestWinsTheSlot()
    {
        await LoginViaApi(EnvConfig.Email, EnvConfig.Password);

        var apiRequestExecutor = new ApiRequestExecutor(Request);
        var payload = JsonSerializer.Serialize(DefaultBookingRequest(), new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true  
        });

        const int parallelAttempts = 5;

        var requests = Enumerable.Range(0, parallelAttempts)
            .Select(_ => Request.PostAsync(BaseUrl + BookingUrl, new APIRequestContextOptions
            {
                DataObject = payload,
                Headers = new Dictionary<string, string> { { "x-csrf-token", apiRequestExecutor.ITKTToken! } }
            }));

        var responses = await Task.WhenAll(requests);

        var succeeded = responses.Count(r => r.Status == 200);
        var rejected  = responses.Count(r => r.Status is 409 or 422 or 400);

        Assert.Multiple(() =>
        {
            Assert.That(succeeded, Is.EqualTo(1), "Only one request for the same slot should go through");
            Assert.That(rejected, Is.EqualTo(parallelAttempts - 1), "The rest should be rejected as the slot's already taken");
        });
    }
}