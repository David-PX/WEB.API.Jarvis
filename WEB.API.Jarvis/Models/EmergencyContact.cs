using System;
using System.Collections.Generic;

namespace WEB.API.Jarvis.Models;

public partial class EmergencyContact
{
    public Guid EmergencyContactsId { get; set; }

    public string? RelationShip { get; set; }

    public Guid? EnrollmentId { get; set; }

    public string? PhoneNumber { get; set; }

    public string? MobileNumber { get; set; }

    public string? Address { get; set; }

    public virtual Enrollment? Enrollment { get; set; }
}
