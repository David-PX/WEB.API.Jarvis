using System;
using System.Collections.Generic;

namespace WEB.API.Jarvis.Models;

public partial class GradeStudent
{
    public Guid? GradeId { get; set; }

    public string? StudentId { get; set; }

    public int? Grade { get; set; }

    public virtual Grade? GradeNavigation { get; set; }

    public virtual Student? Student { get; set; }
}
