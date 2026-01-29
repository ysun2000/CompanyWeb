using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CompanyWeb.Models.CompanyDB;

public partial class Employee
{
      [Display (Name = "ID")]
  public int EmployeeId { get; set; }

     [Required (ErrorMessage = "First Name is mandatory")]
    [MaxLength(20)]
    [MinLength(3)]
      [Display (Name = "First Name")]
   public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "Last Name is mandatory")]
    [MaxLength(20)]
    [MinLength(3)]
      [Display (Name = "Last Name")]
    public string LastName { get; set; } = null!;

    public int? DepartmentId { get; set; }

    public virtual Department? Department { get; set; }
}
