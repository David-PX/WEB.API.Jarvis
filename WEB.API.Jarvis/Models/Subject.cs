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

    public virtual AcademicArea? AcademicArea { get; set; }

    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();

    public virtual SubjectsType? SubjectType { get; set; }
}
