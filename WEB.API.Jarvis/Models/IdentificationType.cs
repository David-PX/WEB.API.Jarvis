using System;
using System.Collections.Generic;

namespace Jarvis.WEB.API.Models;

public partial class IdentificationType
{
    public Guid IdentificationTypeId { get; set; }

    public string? IdentificationTypeName { get; set; }

    public string? Length { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public string? DeletedBy { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
