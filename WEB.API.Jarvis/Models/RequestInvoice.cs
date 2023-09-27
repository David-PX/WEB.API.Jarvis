using System;
using System.Collections.Generic;

namespace WEB.API.Jarvis.Models;

public partial class RequestInvoice
{
    public Guid? InvoiceId { get; set; }

    public Guid? RequestId { get; set; }

    public decimal? FeeAmount { get; set; }

    public virtual Invoice? Invoice { get; set; }

    public virtual Request? Request { get; set; }
}
