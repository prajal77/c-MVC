using System;
using System.Collections.Generic;

namespace LoginRegi.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string EmployeeName { get; set; } = null!;

    public string EmployeeEmail { get; set; } = null!;

    public string EmployeePhoneNumber { get; set; } = null!;

    public string EmployeeAddress { get; set; } = null!;

    public int DepartmentId { get; set; }

    public int DesignationId { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual Designation Designation { get; set; } = null!;
}
