using System;
using System.Collections.Generic;

namespace Jarvis.WEB.API.Models;

public partial class GradeStudent
{
    public Guid? GradeId { get; set; }

    public string? StudentId { get; set; }

    public int? Grade { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public string? DeletedBy { get; set; }

    public virtual Grade? GradeNavigation { get; set; }

    public virtual Student? Student { get; set; }
}
