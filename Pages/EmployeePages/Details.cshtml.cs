using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CompanyWeb.Models.CompanyDB;
using CompanyWeb.Models.CompanyDB;

namespace CompanyWeb.Pages.EmployeePages;

public class DetailsModel : PageModel
{
    private readonly CompanyContext _context;
    public DetailsModel(CompanyContext context)
    {
        _context = context;
    }

    public Employee Employee { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var employee = await _context.Employees.FirstOrDefaultAsync(m => m.EmployeeId == id);
        if (employee is null)
        {
            return NotFound();
        }
        else
        {
            Employee = employee;
        }

        return Page();
    }
}
