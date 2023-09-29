using System;
using System.Collections.Generic;

namespace Jarvis.WEB.API.Models;

public partial class AcademicArea
{
    public string AcademicAreaId { get; set; } = null!;

    public string? AcademicAreaName { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public string? DeletedBy { get; set; }

    public virtual ICollection<Career> Careers { get; set; } = new List<Career>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
