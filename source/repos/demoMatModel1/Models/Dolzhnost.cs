using System;
using System.Collections.Generic;

namespace demoMatModel1.Models;

public partial class Dolzhnost
{
    public int IdDolzh { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
