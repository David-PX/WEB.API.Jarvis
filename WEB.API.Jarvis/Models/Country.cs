﻿using System;
using System.Collections.Generic;

namespace WEB.API.Jarvis.Models;

public partial class Country
{
    public Guid CountryId { get; set; }

    public string? CountryName { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public string? DeletedBy { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    public virtual AspNetUser? CreatedByNavigation { get; set; }

    public virtual AspNetUser? DeletedByNavigation { get; set; }

    public virtual AspNetUser? UpdatedByNavigation { get; set; }
}
