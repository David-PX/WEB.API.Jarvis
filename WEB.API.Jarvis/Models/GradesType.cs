using System;
using System.Collections.Generic;

namespace WEB.API.Jarvis.Models;

public partial class GradesType
{
    public Guid GradeTypeId { get; set; }

    public string? GradeTypeName { get; set; }

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
