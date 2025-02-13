using System;
using System.Collections.Generic;

namespace demoMatModel1.Models;

public partial class AbsenceCalendar
{
    public int Id { get; set; }

    public int? IdEmpl { get; set; }

    public DateOnly? Date { get; set; }

    public string? Cause { get; set; }

    public virtual Employee? IdEmplNavigation { get; set; }
}
