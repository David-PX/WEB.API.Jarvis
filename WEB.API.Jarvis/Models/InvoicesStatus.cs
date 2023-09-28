using System;
using System.Collections.Generic;

namespace WEB.API.Jarvis.Models;

public partial class InvoicesStatus
{
    public Guid InvoiceStatusId { get; set; }

    public string? InvoiceStatusName { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public string? DeletedBy { get; set; }

    public virtual AspNetUser? CreatedByNavigation { get; set; }

    public virtual AspNetUser? DeletedByNavigation { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual AspNetUser? UpdatedByNavigation { get; set; }
}
