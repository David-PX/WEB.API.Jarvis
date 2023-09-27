using System;
using System.Collections.Generic;

namespace WEB.API.Jarvis.Models;

public partial class FeeType
{
    public Guid FeeTypeId { get; set; }

    public string? FeeTypeName { get; set; }

    public virtual ICollection<Fee> Fees { get; set; } = new List<Fee>();
}
