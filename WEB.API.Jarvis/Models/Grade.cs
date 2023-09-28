using System;
using System.Collections.Generic;

namespace WEB.API.Jarvis.Models;

public partial class Grade
{
    public Guid GradeId { get; set; }

    public Guid? SectionId { get; set; }

    public int? MaxGrade { get; set; }

    public Guid? GradeTypeId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public string? DeletedBy { get; set; }

    public virtual AspNetUser? CreatedByNavigation { get; set; }

    public virtual AspNetUser? DeletedByNavigation { get; set; }

    public virtual GradesType? GradeType { get; set; }

    public virtual Section? Section { get; set; }

    public virtual AspNetUser? UpdatedByNavigation { get; set; }
}
