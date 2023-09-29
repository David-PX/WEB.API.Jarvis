using System;
using System.Collections.Generic;

namespace Jarvis.WEB.API.Models;

public partial class Payment
{
    public Guid PaymentId { get; set; }

    public Guid? InvoiceId { get; set; }

    public DateTime? PaymentDate { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public string? DeletedBy { get; set; }

    public virtual Invoice? Invoice { get; set; }
}
