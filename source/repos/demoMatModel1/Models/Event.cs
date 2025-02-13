using System;
using System.Collections.Generic;

namespace demoMatModel1.Models;

public partial class Event
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? IdStatus { get; set; }

    public int? IdType { get; set; }

    public DateOnly? DateBegin { get; set; }

    public DateOnly? DateEnd { get; set; }

    public string? Descr { get; set; }

    public virtual Status? IdStatusNavigation { get; set; }

    public virtual Type? IdTypeNavigation { get; set; }

    public virtual ICollection<Employee> IdEmployees { get; set; } = new List<Employee>();

    public virtual ICollection<Employee> IdEmployers { get; set; } = new List<Employee>();
}
