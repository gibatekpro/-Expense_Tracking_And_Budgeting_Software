namespace ExpenseTrackingAndBudgetingSoftware.Utils;

public static class CurrencyFormat
{
    private static string _format = "£";
    
    public static string ToCurrency(Double value)
    {
        var s = value.ToString("F2");

        return _format + s;
    }
}