using System;
using System.Collections.Generic;

namespace Jarvis.WEB.API.Models;

public partial class Pensum
{
    public Guid PensumId { get; set; }

    public string? PensumName { get; set; }

    public int? Version { get; set; }

    public int? TotalCredits { get; set; }

    public int? TotalTrimester { get; set; }

    public string? CarrerId { get; set; }

    public bool isCurrent { get; set; }

    public virtual Career? Carrer { get; set; }

    public List<PensumSubject>? PensumSubjects { get; set; }


}
