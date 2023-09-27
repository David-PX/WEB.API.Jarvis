using System;
using System.Collections.Generic;

namespace WEB.API.Jarvis.Models;

public partial class Attendance
{
    public Guid AttendanceId { get; set; }

    public Guid? SectionId { get; set; }

    public DateTime? AttendanceDay { get; set; }

    public virtual Section? Section { get; set; }
}
