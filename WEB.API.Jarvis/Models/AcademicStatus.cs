using System;
using System.Collections.Generic;

namespace WEB.API.Jarvis.Models;

public partial class AcademicStatus
{
    public Guid AcademicStatusId { get; set; }

    public string? AcademicStateName { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
