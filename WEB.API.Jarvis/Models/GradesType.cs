﻿using System;
using System.Collections.Generic;

namespace Jarvis.WEB.API.Models;

public partial class GradesType
{
    public Guid GradeTypeId { get; set; }

    public string? GradeTypeName { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public string? DeletedBy { get; set; }

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
