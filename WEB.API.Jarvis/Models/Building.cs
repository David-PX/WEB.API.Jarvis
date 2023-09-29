using System;
using System.Collections.Generic;

namespace Jarvis.WEB.API.Models;

public partial class Building
{
    public string BuildingId { get; set; } = null!;

    public string? BuildingName { get; set; }

    public string? Location { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public string? DeletedBy { get; set; }

    public virtual ICollection<Classroom> Classrooms { get; set; } = new List<Classroom>();
}
