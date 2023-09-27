using System;
using System.Collections.Generic;

namespace WEB.API.Jarvis.Models;

public partial class Career
{
    public Guid CareerId { get; set; }

    public string? CareerName { get; set; }

    public string? AcademicAreaId { get; set; }

    public virtual AcademicArea? AcademicArea { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
