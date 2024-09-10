using ExpenseTrackingAndBudgetingSoftware.Service;
namespace ExpenseTrackingAndBudgetingSoftware.Models;

public class Transaction
{

    private DateOnly _date;
    private double _amount;
    private Category _category;
    private string? _description;
    private TransactionType _transactionType;
    public Transaction(double amount, Category category, 
        TransactionType transactionType, DateOnly date, string? description) {
        
        _description = description;
        _amount = amount;
        _category = category;
        _transactionType = transactionType;
        _date = date;
        
        //Bi-directional. Add transaction to the category
        CategoryService.AddTransaction(this, category);

    }
    
    public double Amount
    {
        get => _amount;
        set => _amount = value;
    }
    public TransactionType TransactionType
    {
        get => _transactionType;
        set => _transactionType = value;
    }
    public string? Description
    {
        get => _description;
        set => _description = value;
    }
    public DateOnly Date
    {
        get => _date;
        set => _date = value;
    }
    public Category Category => _category;

}