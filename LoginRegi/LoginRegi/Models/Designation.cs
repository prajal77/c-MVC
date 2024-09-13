using System;
using System.Collections.Generic;

namespace LoginRegi.Models;

public partial class Designation
{
    public int Id { get; set; }

    public string DesignationName { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
