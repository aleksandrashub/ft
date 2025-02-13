using System;
using System.Collections.Generic;

namespace demoMatModel1.Models;

public partial class Type
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
