using System;
using System.Collections.Generic;

namespace WEB.API.Jarvis.Models;

public partial class Payment
{
    public Guid PaymentId { get; set; }

    public Guid? InvoiceId { get; set; }

    public DateTime? PaymentDate { get; set; }

    public decimal? Amount { get; set; }

    public virtual Invoice? Invoice { get; set; }
}
