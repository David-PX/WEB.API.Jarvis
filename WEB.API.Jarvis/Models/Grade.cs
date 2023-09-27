using System;
using System.Collections.Generic;

namespace WEB.API.Jarvis.Models;

public partial class Grade
{
    public Guid GradeId { get; set; }

    public Guid? SectionId { get; set; }

    public int? MaxGrade { get; set; }

    public Guid? GradeTypeId { get; set; }

    public virtual GradesType? GradeType { get; set; }

    public virtual Section? Section { get; set; }
}
