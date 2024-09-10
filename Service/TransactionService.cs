using ExpenseTrackingAndBudgetingSoftware.Models;
using ExpenseTrackingAndBudgetingSoftware.Utils;

namespace ExpenseTrackingAndBudgetingSoftware.Service;

public static class TransactionService
{
    //
    
    public static void Display(int? count, Transaction transaction)
    {
        
        Console.WriteLine();

        if (count != null)
        {
            Console.WriteLine(
                $"{count + ")",-5}{transaction.Category!.CategoryName,-30}{CurrencyFormat.ToCurrency(transaction.Amount),-5}");

        }else {
            
            Console.WriteLine(
                $"{"",-5}{transaction.Category!.CategoryName,-30}{CurrencyFormat.ToCurrency(transaction.Amount),-5}");
            
        }
        Console.WriteLine($"{"",-5}{DateService.ToStringFormat(transaction.Date),-30}{transaction.Category.CategoryType}");
        if (!string.IsNullOrEmpty(transaction.Description))
        {
            Console.WriteLine($"{"",-5}{"Description: ", -1}{transaction.Description}");
        }
        
        Console.WriteLine();

    }
    
    public static List<Transaction> Sort(List<Transaction> transactions, SortType sortType)
    {
        
        switch (sortType)
        {
            case SortType.AmountAscending:
                return transactions.OrderBy(t => t.Amount).ToList();
            case SortType.AmountDescending:
                return transactions.OrderByDescending(t => t.Amount).ToList();
            case SortType.DateAscending:
                return transactions.OrderBy(t => t.Date).ToList();
            case SortType.DateDescending:
                return transactions.OrderByDescending(t => t.Date).ToList();
            case SortType.CategoryNameAscending:
                return transactions.OrderBy(t => t.Category.CategoryName).ToList();
            case SortType.CategoryNameDescending:
                return transactions.OrderByDescending(t => t.Category.CategoryName).ToList();
            default:
                return transactions.OrderBy(t => t.Date).ToList();
        }
        
    }

}