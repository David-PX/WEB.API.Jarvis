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

    public virtual Classroom? Classroom { get; set; }

    public virtual Section? Section { get; set; }
}
