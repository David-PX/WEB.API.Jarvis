using System;
using System.Collections.Generic;

namespace WEB.API.Jarvis.Models;

public partial class SectionStudent
{
    public Guid? SectionId { get; set; }

    public string? StudentId { get; set; }

    public virtual Section? Section { get; set; }

    public virtual Student? Student { get; set; }
}
