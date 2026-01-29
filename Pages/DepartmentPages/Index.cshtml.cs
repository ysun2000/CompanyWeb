using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CompanyWeb.Models.CompanyDB;
using CompanyWeb.Models.CompanyDB;

namespace CompanyWeb.Pages.DepartmentPages;

public class IndexModel : PageModel
{
    private readonly CompanyContext _context;

    public IndexModel(CompanyContext context)
    {
        _context = context;
    }

    public IList<Department> Department { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Department = await _context.Departments.ToListAsync();
    }
}
