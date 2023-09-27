using System;
using System.Collections.Generic;

namespace WEB.API.Jarvis.Models;

public partial class EmployeesSchedule
{
    public Guid EmployeesSchedulesId { get; set; }

    public Guid? EmployeeId { get; set; }

    public DateTime? Day { get; set; }

    public DateTime? StartHour { get; set; }

    public DateTime? EndHour { get; set; }

    public virtual Employee? Employee { get; set; }
}
