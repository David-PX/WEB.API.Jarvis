﻿using System;
using System.Collections.Generic;

namespace Jarvis.WEB.API.Models;

public partial class Classroom
{
    public Guid ClassroomId { get; set; }

    public string? ClassroomName { get; set; }

    public int? Capacity { get; set; }

    public string? BuildingId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public string? DeletedBy { get; set; }

    public virtual Building? Building { get; set; }

    public virtual ICollection<SectionSchedule> SectionSchedules { get; set; } = new List<SectionSchedule>();
}
