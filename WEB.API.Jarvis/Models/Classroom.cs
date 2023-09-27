using System;
using System.Collections.Generic;

namespace WEB.API.Jarvis.Models;

public partial class Classroom
{
    public Guid ClassroomId { get; set; }

    public string? ClassroomName { get; set; }

    public int? Capacity { get; set; }

    public string? BuildingId { get; set; }

    public virtual Building? Building { get; set; }

    public virtual ICollection<SectionSchedule> SectionSchedules { get; set; } = new List<SectionSchedule>();
}
