using System;
using System.Collections.Generic;

namespace WEB.API.Jarvis.Models;

public partial class IdentificationType
{
    public Guid IdentificationTypeId { get; set; }

    public string? IdentificationTypeName { get; set; }

    public string? Length { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
