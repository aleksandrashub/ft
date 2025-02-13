using System;
using System.Collections.Generic;

namespace demoMatModel1.Models;

public partial class VacationCalendar
{
    public int Id { get; set; }

    public DateOnly? DateBegin { get; set; }

    public DateOnly? DateEnd { get; set; }

    public int? IdEmpl { get; set; }

    public virtual Employee? IdEmplNavigation { get; set; }
}
