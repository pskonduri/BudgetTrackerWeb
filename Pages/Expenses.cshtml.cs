using Microsoft.AspNetCore.Mvc.RazorPages;
using BudgetTrackerWeb.Models;

public class ExpensesModel : PageModel
{
    private readonly BudgetManager _manager;

    public List<Expense> Expenses { get; set; }

    public ExpensesModel(BudgetManager manager)
    {
        _manager = manager;
    }

    public void OnGet()
    {
        Expenses = _manager.Expenses;
    }
}
