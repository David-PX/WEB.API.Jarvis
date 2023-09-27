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

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    public virtual ICollection<SectionSchedule> SectionSchedules { get; set; } = new List<SectionSchedule>();

    public virtual Subject? Subject { get; set; }

    public virtual Employee? Teacher { get; set; }

    public virtual Trimester? Trimester { get; set; }
}
