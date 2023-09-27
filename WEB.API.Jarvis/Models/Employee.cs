using System;
using System.Collections.Generic;

namespace WEB.API.Jarvis.Models;

public partial class Employee
{
    public Guid EmployeeId { get; set; }

    public Guid? SupervisorId { get; set; }

    public string? UserId { get; set; }

    public string? AcademicAreaId { get; set; }

    public virtual AcademicArea? AcademicArea { get; set; }

    public virtual ICollection<EmployeesSchedule> EmployeesSchedules { get; set; } = new List<EmployeesSchedule>();

    public virtual ICollection<Employee> InverseSupervisor { get; set; } = new List<Employee>();

    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();

    public virtual Employee? Supervisor { get; set; }

    public virtual AspNetUser? User { get; set; }
}
