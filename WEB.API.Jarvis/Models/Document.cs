using System;
using System.Collections.Generic;

namespace WEB.API.Jarvis.Models;

public partial class Document
{
    public Guid DocumentId { get; set; }

    public Guid? DocumentTypeId { get; set; }

    public string? Path { get; set; }

    public Guid? EnrollmentId { get; set; }

    public virtual DocumentsType? DocumentType { get; set; }

    public virtual Enrollment? Enrollment { get; set; }
}
