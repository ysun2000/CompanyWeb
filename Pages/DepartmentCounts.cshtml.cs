using Microsoft.AspNetCore.Mvc.RazorPages;
using CompanyWeb.Models.CompanyDB;
using Microsoft.EntityFrameworkCore;

namespace CompanyWeb.Pages;

public class DepartmentCountsModel : PageModel
{
    private readonly CompanyContext _context;

    public DepartmentCountsModel(CompanyContext context)
    {
        _context = context;
    }

    public IList<DepartmentCount> DepartmentCounts { get; set; } = default!;

    public class DepartmentCount
    {
        public Department? Department { get; set; }
        public int Count { get; set; }
    }

    public async Task OnGetAsync()
    {
        DepartmentCounts = await _context.Employees
            .Include(e => e.Department)
            .GroupBy(e => e.Department)
            .Select(g => new DepartmentCount { Department = g.Key, Count = g.Count() })
            .ToListAsync();
    }
}