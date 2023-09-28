using System;
using System.Collections.Generic;

namespace WEB.API.Jarvis.Models;

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

    public virtual AspNetUser? CreatedByNavigation { get; set; }

    public virtual AspNetUser? DeletedByNavigation { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual AspNetUser? UpdatedByNavigation { get; set; }
}
