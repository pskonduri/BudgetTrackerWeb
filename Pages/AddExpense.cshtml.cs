using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BudgetTrackerWeb.Models;

public class AddExpenseModel : PageModel
{
    private readonly BudgetManager _manager;

    [BindProperty]
    public double Amount { get; set; }

    [BindProperty]
    public string Category { get; set; }

    [BindProperty]
    public DateTime Date { get; set; } = DateTime.Now;

    public AddExpenseModel(BudgetManager manager)
    {
        _manager = manager;
    }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
            return Page();

        _manager.AddExpense(Amount, Category, Date);

        return RedirectToPage("/Expenses");
    }
}

