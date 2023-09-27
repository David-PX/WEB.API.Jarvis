using System;
using System.Collections.Generic;

namespace WEB.API.Jarvis.Models;

public partial class Invoice
{
    public Guid InvoiceId { get; set; }

    public string? StudentId { get; set; }

    public decimal? TotalAmount { get; set; }

    public Guid? InvoiceStatusId { get; set; }

    public virtual InvoicesStatus? InvoiceStatus { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Student? Student { get; set; }
}
