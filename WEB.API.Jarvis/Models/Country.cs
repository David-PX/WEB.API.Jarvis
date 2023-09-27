using System;
using System.Collections.Generic;

namespace WEB.API.Jarvis.Models;

public partial class Country
{
    public Guid CountryId { get; set; }

    public string? CountryName { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();
}
