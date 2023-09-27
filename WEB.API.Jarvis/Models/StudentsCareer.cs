using System;
using System.Collections.Generic;

namespace WEB.API.Jarvis.Models;

public partial class StudentsCareer
{
    public string? StudentId { get; set; }

    public Guid? CareerId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual Career? Career { get; set; }

    public virtual Student? Student { get; set; }
}
