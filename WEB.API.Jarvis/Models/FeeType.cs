using System;
using System.Collections.Generic;

namespace Jarvis.WEB.API.Models;

public partial class FeeType
{
    public Guid FeeTypeId { get; set; }

    public string? FeeTypeName { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public string? DeletedBy { get; set; }

    public virtual ICollection<Fee> Fees { get; set; } = new List<Fee>();
}
