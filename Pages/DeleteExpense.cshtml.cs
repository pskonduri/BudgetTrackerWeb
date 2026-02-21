using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BudgetTrackerWeb.Models;

public class DeleteExpenseModel : PageModel
{
    private readonly BudgetManager _manager;

    public Expense Expense { get; set; }

    [BindProperty]
    public int Id { get; set; }

    public DeleteExpenseModel(BudgetManager manager)
    {
        _manager = manager;
    }

    public IActionResult OnGet(int id)
    {
        if (id < 0 || id >= _manager.Expenses.Count)
            return RedirectToPage("/Expenses");

        Id = id;
        Expense = _manager.Expenses[id];

        return Page();
    }

    public IActionResult OnPost()
    {
        _manager.DeleteExpense(Id);
        return RedirectToPage("/Expenses");
    }
}

