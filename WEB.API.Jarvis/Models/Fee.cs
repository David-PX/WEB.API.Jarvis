using System;
using System.Collections.Generic;

namespace WEB.API.Jarvis.Models;

public partial class Fee
{
    public Guid FeeId { get; set; }

    public string? FeeName { get; set; }

    public decimal? Amount { get; set; }

    public Guid? FeeTypeId { get; set; }

    public virtual FeeType? FeeType { get; set; }

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}
