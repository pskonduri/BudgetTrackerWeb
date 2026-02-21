using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BudgetTrackerWeb.Models;

public class MonthlySummaryModel : PageModel
{
    private readonly BudgetManager _manager;

    public List<Expense> MonthlyExpenses { get; set; } = new();
    public double Total { get; set; }

    [BindProperty(SupportsGet = true)]
    public int Month { get; set; }

    [BindProperty(SupportsGet = true)]
    public int Year { get; set; }

    public MonthlySummaryModel(BudgetManager manager)
    {
        _manager = manager;
    }

    public void OnGet()
    {
        if (Month > 0 && Year > 0)
        {
            MonthlyExpenses = _manager.GetMonthlyExpenses(Year, Month);
            Total = MonthlyExpenses.Sum(e => e.Amount);
        }
    }
}

