using System;
using System.Collections.Generic;

namespace WEB.API.Jarvis.Models;

public partial class Subject
{
    public string SubjectId { get; set; } = null!;

    public string? SubjectName { get; set; }

    public int? Credits { get; set; }

    public Guid? SubjectTypeId { get; set; }

    public string? AcademicAreaId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public string? DeletedBy { get; set; }

    public virtual AcademicArea? AcademicArea { get; set; }

    public virtual AspNetUser? CreatedByNavigation { get; set; }

    public virtual AspNetUser? DeletedByNavigation { get; set; }

    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();

    public virtual SubjectsType? SubjectType { get; set; }

    public virtual AspNetUser? UpdatedByNavigation { get; set; }
}
