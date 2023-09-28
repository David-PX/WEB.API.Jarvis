using System;
using System.Collections.Generic;

namespace WEB.API.Jarvis.Models;

public partial class City
{
    public Guid CityId { get; set; }

    public string? CityName { get; set; }

    public Guid? CountryId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public string? DeletedBy { get; set; }

    public virtual Country? Country { get; set; }

    public virtual AspNetUser? CreatedByNavigation { get; set; }

    public virtual AspNetUser? DeletedByNavigation { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual AspNetUser? UpdatedByNavigation { get; set; }
}
