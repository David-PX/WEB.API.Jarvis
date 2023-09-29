using System;
using System.Collections.Generic;

namespace Jarvis.WEB.API.Models;

public partial class Document
{
    public Guid DocumentId { get; set; }

    public Guid? DocumentTypeId { get; set; }

    public string? Path { get; set; }

    public Guid? EnrollmentId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public string? DeletedBy { get; set; }

    public virtual DocumentsType? DocumentType { get; set; }

    public virtual Enrollment? Enrollment { get; set; }
}
