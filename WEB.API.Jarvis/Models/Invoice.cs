﻿using System;
using System.Collections.Generic;

namespace WEB.API.Jarvis.Models;

public partial class Invoice
{
    public Guid InvoiceId { get; set; }

    public string? StudentId { get; set; }

    public decimal? TotalAmount { get; set; }

    public Guid? InvoiceStatusId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public string? DeletedBy { get; set; }

    public virtual AspNetUser? CreatedByNavigation { get; set; }

    public virtual AspNetUser? DeletedByNavigation { get; set; }

    public virtual InvoicesStatus? InvoiceStatus { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Student? Student { get; set; }

    public virtual AspNetUser? UpdatedByNavigation { get; set; }
}
