using System;
using System.Collections.Generic;

namespace demoMatModel1.Models;

public partial class TypeMater
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
}
