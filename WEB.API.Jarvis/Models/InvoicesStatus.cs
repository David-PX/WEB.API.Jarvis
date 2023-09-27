using System;
using System.Collections.Generic;

namespace WEB.API.Jarvis.Models;

public partial class InvoicesStatus
{
    public Guid InvoiceStatusId { get; set; }

    public string? InvoiceStatusName { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}
