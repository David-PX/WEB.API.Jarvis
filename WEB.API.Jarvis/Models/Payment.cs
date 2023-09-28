using System;
using System.Collections.Generic;

namespace WEB.API.Jarvis.Models;

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

    public virtual AspNetUser? CreatedByNavigation { get; set; }

    public virtual AspNetUser? DeletedByNavigation { get; set; }

    public virtual Invoice? Invoice { get; set; }

    public virtual AspNetUser? UpdatedByNavigation { get; set; }
}
