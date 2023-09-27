using System;
using System.Collections.Generic;

namespace WEB.API.Jarvis.Models;

public partial class Trimester
{
    public Guid IdTrimestres { get; set; }

    public int? Year { get; set; }

    public int? Period { get; set; }

    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();

    public virtual ICollection<TrimesterDate> TrimesterDates { get; set; } = new List<TrimesterDate>();
}
