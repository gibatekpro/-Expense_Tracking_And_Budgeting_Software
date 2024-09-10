namespace ExpenseTrackingAndBudgetingSoftware.Service;

public static class DateService
{ 
    public static string DateFormat => "dd/MM/yyyy";
    public static DateOnly? ToDateOnly(string date)
    {
        try
        {
            DateOnly parsedDate = DateOnly.ParseExact(date, DateFormat);

            return parsedDate;
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Could not convert this string to date. " + ex.Message);
            return null;
        }
    }
    public static string ToStringFormat(DateOnly date)
    {
        return date.ToString("dddd, dd MMM yyyy");
    }
    public static string ToYearStringFormat(DateOnly date)
    {
        return date.ToString("yyyy");
    }
    public static string ToMonthYearStringFormat(DateOnly date)
    {
        return date.ToString("MMMM, yyyy");
    }
    public static string ToDayMonthYearStringFormat(DateOnly date)
    {
        return date.ToString("dddd, MMMM, yyyy");
    }
}