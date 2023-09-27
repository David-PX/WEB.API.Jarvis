using System;
using System.Collections.Generic;

namespace WEB.API.Jarvis.Models;

public partial class Report
{
    public Guid ReportId { get; set; }

    public string? Description { get; set; }

    public Guid? SectionId { get; set; }

    public string? StudentId { get; set; }

    public bool? State { get; set; }

    public virtual Section? Section { get; set; }

    public virtual Student? Student { get; set; }
}
