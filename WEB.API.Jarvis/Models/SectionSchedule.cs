using System;
using System.Collections.Generic;

namespace WEB.API.Jarvis.Models;

public partial class SectionSchedule
{
    public Guid SectionScheduleId { get; set; }

    public Guid? SectionId { get; set; }

    public Guid? ClassroomId { get; set; }

    public string? Day { get; set; }

    public DateTime? StartHour { get; set; }

    public DateTime? EndHour { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public string? DeletedBy { get; set; }

    public virtual Classroom? Classroom { get; set; }

    public virtual AspNetUser? CreatedByNavigation { get; set; }

    public virtual AspNetUser? DeletedByNavigation { get; set; }

    public virtual Section? Section { get; set; }

    public virtual AspNetUser? UpdatedByNavigation { get; set; }
}
