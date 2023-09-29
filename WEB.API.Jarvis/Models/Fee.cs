﻿using System;
using System.Collections.Generic;

namespace Jarvis.WEB.API.Models;

public partial class Fee
{
    public Guid FeeId { get; set; }

    public string? FeeName { get; set; }

    public decimal? Amount { get; set; }

    public Guid? FeeTypeId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public string? DeletedBy { get; set; }

    public virtual FeeType? FeeType { get; set; }

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}
