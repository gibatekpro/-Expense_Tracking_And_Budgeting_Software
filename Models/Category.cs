namespace ExpenseTrackingAndBudgetingSoftware.Models;

public class Category
{

    private string _categoryName;

    private string? _categoryDescription;

    private readonly List<Transaction> _transactions;

    private CategoryType _categoryType;

    public Category(string categoryName, CategoryType categoryType)
    {
        _categoryName = categoryName;

        _categoryType = categoryType;

        _transactions = new List<Transaction>();
    }
    
public string CategoryName
    {
        get => _categoryName;
        set => _categoryName = value;
    }

    public CategoryType CategoryType
    {
        get => _categoryType;
        set => _categoryType = value;
    }

    public string? CategoryDescription
    {
        get => _categoryDescription;
        set => _categoryDescription = value;
    }

    
    public List<Transaction> Transactions => _transactions;

}