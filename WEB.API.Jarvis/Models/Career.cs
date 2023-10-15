using System;
using System.Collections.Generic;

namespace Jarvis.WEB.API.Models;

public partial class Career
{
    public Guid CareerId { get; set; }

    public string? CareerName { get; set; }

    public string? AcademicAreaId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public string? DeletedBy { get; set; }

    public virtual AcademicArea? AcademicArea { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual ICollection<Pensum> Pensums { get; set; } = new List<Pensum>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
