﻿using System;
using System.Collections.Generic;

namespace Jarvis.WEB.API.Models;

public partial class TrimesterDate
{
    public Guid TrimesterDateId { get; set; }

    public string? TrimesterDateName { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public Guid? TrimesterId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public string? DeletedBy { get; set; }

    public virtual Trimester? Trimester { get; set; }
}
