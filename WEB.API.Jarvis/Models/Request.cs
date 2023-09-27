using System;
using System.Collections.Generic;

namespace WEB.API.Jarvis.Models;

public partial class Request
{
    public Guid RequestId { get; set; }

    public string? StudentId { get; set; }

    public DateTime? RequestDate { get; set; }

    public Guid? FeeId { get; set; }

    public virtual Fee? Fee { get; set; }

    public virtual Student? Student { get; set; }
}
