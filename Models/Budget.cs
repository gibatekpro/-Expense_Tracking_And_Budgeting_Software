namespace ExpenseTrackingAndBudgetingSoftware.Models;

public class Budget
{
    private double _amount;
    private DateOnly _startDate;
    private DateOnly _endDate;
    private Category _category;
    private List<Transaction> _transactions;

    public Budget(double amount, DateOnly startDate, DateOnly endDate, Category category)
    {

        if (category is { CategoryType: CategoryType.Income })
        {
            //Other checks exist, the code may never have to throw this exception
            throw new Exception("Cannot have a budget for Income");
        }

        _amount = amount;
        _startDate = startDate;
        _endDate = endDate;
        _category = category;

        _transactions = new List<Transaction>();

        //Check for existing transactions that fall within budget period
        foreach (var transaction in _category.Transactions)
        {
            if (transaction.Date >= _startDate && transaction.Date <= _endDate)
            {
                _transactions.Add(transaction);
            }
        }
    }

    

public double Amount
    {
        get => _amount;
        set => _amount = value;
    }

    public DateOnly StartDate
    {
        get => _startDate;
        set => _startDate = value;
    }

    public DateOnly EndDate
    {
        get => _endDate;
        set => _endDate = value;
    }


    public Category Category
    {
        get => _category;
        set => _category = value;
    }

    public List<Transaction> GetTransactions()
    {
        _transactions = new List<Transaction>();

        foreach (var transaction in _category.Transactions)
        {
            if (transaction.Date >= _startDate && transaction.Date <= _endDate)
            {
                _transactions.Add(transaction);
            }
        }

        return _transactions;
    }

}