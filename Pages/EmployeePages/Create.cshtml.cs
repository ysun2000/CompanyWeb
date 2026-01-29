using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CompanyWeb.Models.CompanyDB;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompanyWeb.Pages.EmployeePages;

public class CreateModel : PageModel
{
    private readonly CompanyContext _context;

    public CreateModel(CompanyContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> OnGetAsync()
    {
        await LoadDepartmentList();
        return Page();
    }

    [BindProperty]
    public Employee Employee { get; set; } = default!;

    public SelectList? DepartmentList { get; set; }
    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            await LoadDepartmentList();
            return Page();
        }

        _context.Employees.Add(Employee);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
    private async Task LoadDepartmentList()
    {
        var departments = await _context.Departments.ToListAsync();
        DepartmentList = new SelectList(departments, "DepartmentId", "DepartmentName");
    }
}
