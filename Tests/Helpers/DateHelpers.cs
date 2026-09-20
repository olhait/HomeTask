namespace Tests.Helpers;

public static class DateHelpers
{
    public static string Today =>
        DateTime.Today.ToString("yyyy-MM-dd");
    
    public static string TodayOrNextWeekday =>
        DateTime.Today.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday
            ? WeekdayDates().First()
            : Today;
    public static IEnumerable<string> WeekdayDates()
    {
        var today = DateTime.Today;
        var daysUntilMonday = ((int)DayOfWeek.Monday - (int)today.DayOfWeek + 7) % 7;
        var monday = today.DayOfWeek == DayOfWeek.Monday ? today
            : today.DayOfWeek  > DayOfWeek.Friday ? today.AddDays(daysUntilMonday)
            : today.AddDays(-(int)today.DayOfWeek + (int)DayOfWeek.Monday);

        return Enumerable.Range(0, 5).Select(i => monday.AddDays(i).ToString("yyyy-MM-dd"));
    }
}