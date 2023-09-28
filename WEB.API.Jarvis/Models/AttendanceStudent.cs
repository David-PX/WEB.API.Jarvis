using System;
using System.Collections.Generic;

namespace WEB.API.Jarvis.Models;

public partial class AttendanceStudent
{
    public Guid? AttendanceId { get; set; }

    public string? StudentId { get; set; }

    public Guid? StudentsAttendanceStatusId { get; set; }

    public string? Observations { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public string? DeletedBy { get; set; }

    public virtual Attendance? Attendance { get; set; }

    public virtual AspNetUser? CreatedByNavigation { get; set; }

    public virtual AspNetUser? DeletedByNavigation { get; set; }

    public virtual Student? Student { get; set; }

    public virtual StudentAttendanceStatus? StudentsAttendanceStatus { get; set; }

    public virtual AspNetUser? UpdatedByNavigation { get; set; }
}
