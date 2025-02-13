using System;
using System.Collections.Generic;

namespace demoMatModel1.Models;

public partial class Podrazd
{
    public int IdPodrazd { get; set; }

    public string? Name { get; set; }

    public string? Descr { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Podrazd> IdAddedPodrazds { get; set; } = new List<Podrazd>();

    public virtual ICollection<Podrazd> IdPodrazds { get; set; } = new List<Podrazd>();
}
