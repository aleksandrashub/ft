using System;
using System.Collections.Generic;

namespace demoMatModel1.Models;

public partial class Material
{
    public int IdMaterial { get; set; }

    public string? Name { get; set; }

    public DateOnly? DateUtverzhd { get; set; }

    public DateOnly? DateIzmenen { get; set; }

    public int? IdStatus { get; set; }

    public int? IdType { get; set; }

    public string? Oblast { get; set; }

    public int? IdAuthor { get; set; }

    public virtual Employee? IdAuthorNavigation { get; set; }

    public virtual StatusMater? IdStatusNavigation { get; set; }

    public virtual TypeMater? IdTypeNavigation { get; set; }
}
