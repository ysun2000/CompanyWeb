using Microsoft.AspNetCore.Mvc.RazorPages;
using CompanyWeb.Models.CompanyDB;
using Microsoft.EntityFrameworkCore;

namespace CompanyWeb.Pages;

public class DepartmentEmployeesModel : PageModel
{
    private readonly CompanyContext _context;

    public DepartmentEmployeesModel(CompanyContext context)
    {
        _context = context;
    }

    public IList<Department> Departments { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Departments = await _context.Departments.Include(d => d.Employees).ToListAsync();
    }
}