using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CompanyWeb.Models.CompanyDB;

namespace CompanyWeb.Pages.EmployeePages;

public class EditModel : PageModel
{
    private readonly CompanyContext _context;

    public EditModel(CompanyContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Employee Employee { get; set; } = default!;

    public SelectList? DepartmentList { get; set; }

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
        Employee = employee;
        await LoadDepartmentList();
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            await LoadDepartmentList();
            return Page();
        }

        _context.Attach(Employee).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EmployeeExists(Employee.EmployeeId))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool EmployeeExists(int id)
    {
        return _context.Employees.Any(e => e.EmployeeId == id);
    }

    private async Task LoadDepartmentList()
    {
        var departments = await _context.Departments.ToListAsync();
        DepartmentList = new SelectList(departments, "DepartmentId", "DepartmentName");
    }
}
