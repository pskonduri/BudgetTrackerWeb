using Microsoft.AspNetCore.Mvc.RazorPages;
using BudgetTrackerWeb.Models;
using System.Collections.Generic;

public class CategoryReportModel : PageModel
{
    private readonly BudgetManager _manager;

    public List<(string Category, double Total, int Count)> Report { get; set; }

    public CategoryReportModel(BudgetManager manager)
    {
        _manager = manager;
    }

    public void OnGet()
    {
        Report = _manager.GetCategoryReport().ToList();
    }
}

