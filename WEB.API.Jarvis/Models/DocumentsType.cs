using System;
using System.Collections.Generic;

namespace WEB.API.Jarvis.Models;

public partial class DocumentsType
{
    public Guid DocumentTypeId { get; set; }

    public string? DocumentTypeName { get; set; }

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();
}
