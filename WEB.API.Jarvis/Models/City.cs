using System;
using System.Collections.Generic;

namespace WEB.API.Jarvis.Models;

public partial class City
{
    public Guid CityId { get; set; }

    public string? CityName { get; set; }

    public Guid? CountryId { get; set; }

    public virtual Country? Country { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
