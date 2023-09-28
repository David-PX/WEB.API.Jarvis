using System;
using System.Collections.Generic;

namespace WEB.API.Jarvis.Models;

public partial class Section
{
    public Guid SectionId { get; set; }

    public int? Number { get; set; }

    public string? SubjectId { get; set; }

    public Guid? TeacherId { get; set; }

    public Guid? TrimesterId { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public string? DeletedBy { get; set; }

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual AspNetUser? CreatedByNavigation { get; set; }

    public virtual AspNetUser? DeletedByNavigation { get; set; }

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    public virtual ICollection<SectionSchedule> SectionSchedules { get; set; } = new List<SectionSchedule>();

    public virtual Subject? Subject { get; set; }

    public virtual Employee? Teacher { get; set; }

    public virtual Trimester? Trimester { get; set; }

    public virtual AspNetUser? UpdatedByNavigation { get; set; }
}
