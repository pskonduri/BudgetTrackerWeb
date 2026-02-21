using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BudgetTrackerWeb.Models;

public class EditExpenseModel : PageModel
{
    private readonly BudgetManager _manager;

    [BindProperty]
    public int Id { get; set; }

    [BindProperty]
    public double Amount { get; set; }

    [BindProperty]
    public string Category { get; set; }

    [BindProperty]
    public DateTime Date { get; set; }

    public EditExpenseModel(BudgetManager manager)
    {
        _manager = manager;
    }

    public IActionResult OnGet(int id)
    {
        if (id < 0 || id >= _manager.Expenses.Count)
            return RedirectToPage("/Expenses");

        var exp = _manager.Expenses[id];

        Id = id;
        Amount = exp.Amount;
        Category = exp.Category;
        Date = exp.Date;

        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
            return Page();

        _manager.EditExpense(Id, Amount, Category, Date);

        return RedirectToPage("/Expenses");
    }
}

