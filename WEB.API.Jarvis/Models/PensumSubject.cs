using System;
using System.Collections.Generic;

namespace Jarvis.WEB.API.Models;

public partial class PensumSubject
{
    public Guid? PensumId { get; set; }

    public string? SubjectId { get; set; }

    public int? TrimesterNumber { get; set; }

    public virtual Pensum? Pensum { get; set; }
    public virtual Subject? Subject { get; set; }
}
