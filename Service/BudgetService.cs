using ExpenseTrackingAndBudgetingSoftware.Models;
using ExpenseTrackingAndBudgetingSoftware.Utils;

namespace ExpenseTrackingAndBudgetingSoftware.Service;

public static class BudgetService
{
    
    public static void Display(int? count, Budget budget)
    {
        if (count != null)
        {
            Console.WriteLine(
                $"{count + ")",-5}{budget.Category!.CategoryName,-30}{"Amount Budgeted: " + CurrencyFormat.ToCurrency(budget.Amount),-5}");
            Console.WriteLine(
                $"{"",-5}{"Budget Period",-30}{DateService.ToStringFormat(budget.StartDate),-5} - {DateService.ToStringFormat(budget.EndDate),-5}");
            Console.WriteLine(
                $"{"",-5}{"Total Amount Spent",-30}{CurrencyFormat.ToCurrency(GetTransactionsTotal(budget)),-5}");
            Console.WriteLine(
                $"{"",-5}{"Balance",-30}{CurrencyFormat.ToCurrency(GetBalance(budget)),-5}");
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine(
                $"{"",-5}{budget.Category!.CategoryName,-30}{"Amount Budgeted: " + CurrencyFormat.ToCurrency(budget.Amount),-5}");
            Console.WriteLine(
                $"{"",-5}{"Budget Period",-30}{DateService.ToStringFormat(budget.StartDate),-5} - {DateService.ToStringFormat(budget.EndDate),-5}");
            Console.WriteLine(
                $"{"",-5}{"Total Amount Spent",-30}{CurrencyFormat.ToCurrency(GetTransactionsTotal(budget)),-5}");
            Console.WriteLine(
                $"{"",-5}{"Balance",-30}{CurrencyFormat.ToCurrency(GetBalance(budget)),-5}");
        }

        if (budget.GetTransactions().Count == 0) {
            
            Console.WriteLine();

            Console.Write($"{"",-5}{new string('-', 10)}");
            Console.Write("No transaction within this period");
            Console.Write($"{new string('-', 10)}");

            Console.WriteLine();
            
        }
        else {
            Console.WriteLine();

            Console.Write($"{"",-5}{new string('-', 10)}");
            Console.Write("Transactions Carried Out");
            Console.Write($"{new string('-', 10)}");

            Console.WriteLine();

            int transactionsCount = 1;

            foreach (var transaction in budget.GetTransactions())
            {
                Console.WriteLine(
                    $"{"",-5}{transactionsCount + ")",-5}{transaction.Category.CategoryName,-30}{CurrencyFormat.ToCurrency(transaction.Amount),-5}");

                Console.WriteLine($"{"",-10}{DateService.ToStringFormat(transaction.Date),-30}{budget.Category.CategoryType}");
                if (!string.IsNullOrEmpty(transaction.Description))
                {
                    Console.WriteLine($"{"",-10}{"Description: ",-1}{transaction.Description}");
                }

                transactionsCount++;
            }
        }

        Console.WriteLine();
    }
    public static List<Budget> Sort(List<Budget> budgets, SortType sortType) {
        
        switch (sortType)
        {
            case SortType.DateDescending:
                return budgets.OrderByDescending(t => t.EndDate).ToList();
            default:
                return budgets.OrderByDescending(t => t.EndDate).ToList();
        }
        
    }
    
    private static Double GetTransactionsTotal(Budget budget)
    {
        return budget.GetTransactions().Sum(transaction => transaction.Amount);
    }

    private static  Double GetBalance(Budget budget)
    {
        return budget.Amount - GetTransactionsTotal(budget);
    }
    
}