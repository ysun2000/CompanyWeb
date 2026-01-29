using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CompanyWeb.Models.CompanyDB;

public partial class Department
{
    [Display(Name = "ID")]
    public int DepartmentId { get; set; }

    [Required(ErrorMessage = "Department Name is mandatory")]
    [MaxLength(20)]
    [MinLength(3)]
    [Display(Name = "Department Name")]
    public string DepartmentName { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
