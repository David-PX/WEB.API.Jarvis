using System;
using System.Collections.Generic;

namespace WEB.API.Jarvis.Models;

public partial class Building
{
    public string BuildingId { get; set; } = null!;

    public string? BuildingName { get; set; }

    public string? Location { get; set; }

    public virtual ICollection<Classroom> Classrooms { get; set; } = new List<Classroom>();
}
