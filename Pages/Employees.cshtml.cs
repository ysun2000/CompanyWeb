using Microsoft.AspNetCore.Mvc.RazorPages;
using CompanyWeb.Models.CompanyDB;
using Microsoft.EntityFrameworkCore;

namespace CompanyWeb.Pages
{
    public class EmployeesModel : PageModel
    {
        private readonly CompanyContext _context;

        public EmployeesModel(CompanyContext context)
        {
            _context = context;
        }

        public IList<Employee> Employees { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Employees = await _context.Employees.Include(e => e.Department).ToListAsync();
        }
    }
}
