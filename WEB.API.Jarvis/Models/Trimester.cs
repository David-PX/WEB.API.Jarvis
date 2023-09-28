using System;
using System.Collections.Generic;

namespace WEB.API.Jarvis.Models;

public partial class Trimester
{
    public Guid IdTrimestres { get; set; }

    public int? Year { get; set; }

    public int? Period { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public string? DeletedBy { get; set; }

    public virtual AspNetUser? CreatedByNavigation { get; set; }

    public virtual AspNetUser? DeletedByNavigation { get; set; }

    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();

    public virtual ICollection<TrimesterDate> TrimesterDates { get; set; } = new List<TrimesterDate>();

    public virtual AspNetUser? UpdatedByNavigation { get; set; }
}
