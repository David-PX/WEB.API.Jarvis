using System;
using System.Collections.Generic;

namespace Jarvis.WEB.API.Models;

public partial class StudentsCareer
{
    public string? StudentId { get; set; }

    public string? CareerId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public string? DeletedBy { get; set; }

    public virtual Career? Career { get; set; }

    public virtual Student? Student { get; set; }
}
