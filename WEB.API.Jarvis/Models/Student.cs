using System;
using System.Collections.Generic;

namespace WEB.API.Jarvis.Models;

public partial class Student
{
    public string StudentId { get; set; } = null!;

    public Guid? CareerId { get; set; }

    public Guid? EnrollmentId { get; set; }

    public Guid? AcademicStatusId { get; set; }

    public string? UserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public string? DeletedBy { get; set; }

    public virtual AcademicStatus? AcademicStatus { get; set; }

    public virtual Career? Career { get; set; }

    public virtual AspNetUser? CreatedByNavigation { get; set; }

    public virtual AspNetUser? DeletedByNavigation { get; set; }

    public virtual Enrollment? Enrollment { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();

    public virtual AspNetUser? UpdatedByNavigation { get; set; }

    public virtual AspNetUser? User { get; set; }
}
