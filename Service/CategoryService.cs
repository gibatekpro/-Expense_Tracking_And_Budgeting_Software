using ExpenseTrackingAndBudgetingSoftware.Models;

namespace ExpenseTrackingAndBudgetingSoftware.Service;

public static class CategoryService
{
    
    public static void AddTransaction(Transaction transaction, Category category)
    {
        category.Transactions.Add(transaction);
        
    }

    public static void Display(int? count, Category category)
    {
        
        Console.WriteLine();

        if (count != null)
        {

            Console.WriteLine(
                $"{count + ")",-5}{category.CategoryName,-30}{category.CategoryType.ToString(),-5}");

        }else {
            
            Console.WriteLine(
                $"{"",-5}{category.CategoryName,-30}{category.CategoryType.ToString(),-5}");
        }
        Console.WriteLine();
    }

    public static List<Category> Sort(List<Category> categories, SortType sortType)
    {
        
        switch (sortType)
        {
            case SortType.Name:
                return categories.OrderBy(t => t.CategoryName).ToList();
            case SortType.FrequentlyUsed:
                return categories.OrderByDescending(t => t.Transactions.Count).ToList();
            default:
                return categories.OrderBy(t => t.CategoryName).ToList();
        }
        
    }
}