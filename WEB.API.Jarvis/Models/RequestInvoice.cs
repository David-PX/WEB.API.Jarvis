using System;
using System.Collections.Generic;

namespace WEB.API.Jarvis.Models;

public partial class RequestInvoice
{
    public Guid? InvoiceId { get; set; }

    public Guid? RequestId { get; set; }

    public decimal? FeeAmount { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public string? DeletedBy { get; set; }

    public virtual AspNetUser? CreatedByNavigation { get; set; }

    public virtual AspNetUser? DeletedByNavigation { get; set; }

    public virtual Invoice? Invoice { get; set; }

    public virtual Request? Request { get; set; }

    public virtual AspNetUser? UpdatedByNavigation { get; set; }
}
