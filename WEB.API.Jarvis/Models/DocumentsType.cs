using System;
using System.Collections.Generic;

namespace WEB.API.Jarvis.Models;

public partial class DocumentsType
{
    public Guid DocumentTypeId { get; set; }

    public string? DocumentTypeName { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public string? DeletedBy { get; set; }

    public virtual AspNetUser? CreatedByNavigation { get; set; }

    public virtual AspNetUser? DeletedByNavigation { get; set; }

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual AspNetUser? UpdatedByNavigation { get; set; }
}
