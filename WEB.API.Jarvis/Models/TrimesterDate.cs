using System;
using System.Collections.Generic;

namespace WEB.API.Jarvis.Models;

public partial class TrimesterDate
{
    public Guid TrimesterDateId { get; set; }

    public string? TrimesterDateName { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public Guid? TrimesterId { get; set; }

    public virtual Trimester? Trimester { get; set; }
}
