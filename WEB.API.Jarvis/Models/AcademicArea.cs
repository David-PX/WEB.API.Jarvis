using System;
using System.Collections.Generic;

namespace WEB.API.Jarvis.Models;

public partial class AcademicArea
{
    public string AcademicAreaId { get; set; } = null!;

    public string? AcademicAreaName { get; set; }

    public virtual ICollection<Career> Careers { get; set; } = new List<Career>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
