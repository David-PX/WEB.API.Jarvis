using System;
using System.Collections.Generic;

namespace Jarvis.WEB.API.Models;

public partial class AcademicStatus
{
    public Guid AcademicStatusId { get; set; }

    public string? AcademicStateName { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public string? DeletedBy { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
