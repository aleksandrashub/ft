using System;
using System.Collections.Generic;

namespace demoMatModel1.Models;

public partial class Employee
{
    public int IdEmp { get; set; }

    public string? Fio { get; set; }

    public int? IdDolzhnost { get; set; }

    public string? RabPhone { get; set; }

    public string? LichnPhone { get; set; }

    public string? Mail { get; set; }

    public string? Cabinet { get; set; }

    public DateOnly? Birthday { get; set; }

    public int? IdRukvod { get; set; }

    public int? IdPomoshnik { get; set; }

    public int? IdPodrazd { get; set; }

    public virtual ICollection<AbsenceCalendar> AbsenceCalendars { get; set; } = new List<AbsenceCalendar>();

    public virtual Dolzhnost? IdDolzhnostNavigation { get; set; }

    public virtual Podrazd? IdPodrazdNavigation { get; set; }

    public virtual Employee? IdPomoshnikNavigation { get; set; }

    public virtual Employee? IdRukvodNavigation { get; set; }

    public virtual ICollection<Employee> InverseIdPomoshnikNavigation { get; set; } = new List<Employee>();

    public virtual ICollection<Employee> InverseIdRukvodNavigation { get; set; } = new List<Employee>();

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();

    public virtual ICollection<VacationCalendar> VacationCalendars { get; set; } = new List<VacationCalendar>();

    public virtual ICollection<Event> IdEvents { get; set; } = new List<Event>();

    public virtual ICollection<Event> IdEventsNavigation { get; set; } = new List<Event>();
}
