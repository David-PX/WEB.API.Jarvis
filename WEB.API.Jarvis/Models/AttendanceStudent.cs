using System;
using System.Collections.Generic;

namespace WEB.API.Jarvis.Models;

public partial class AttendanceStudent
{
    public Guid? AttendanceId { get; set; }

    public string? StudentId { get; set; }

    public Guid? StudentsAttendanceStatusId { get; set; }

    public string? Observations { get; set; }

    public virtual Attendance? Attendance { get; set; }

    public virtual Student? Student { get; set; }

    public virtual StudentAttendanceStatus? StudentsAttendanceStatus { get; set; }
}
