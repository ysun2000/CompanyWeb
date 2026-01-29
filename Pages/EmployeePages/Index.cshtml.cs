using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CompanyWeb.Models.CompanyDB;

namespace CompanyWeb.Pages.EmployeePages;

public class IndexModel : PageModel
{
    private readonly CompanyContext _context;

    public IndexModel(CompanyContext context)
    {
        _context = context;
    }

    public IList<Employee> Employee { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Employee = await _context.Employees.ToListAsync();
    }
}
