using System;
using System.Collections.Generic;

namespace WEB.API.Jarvis.Models;

public partial class SubjectsType
{
    public Guid SubjectTypeId { get; set; }

    public string? SubjectTypeName { get; set; }

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
