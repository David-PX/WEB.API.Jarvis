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

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public string? DeletedBy { get; set; }

    public virtual AspNetUser? CreatedByNavigation { get; set; }

    public virtual AspNetUser? DeletedByNavigation { get; set; }

    public virtual Enrollment? Enrollment { get; set; }

    public virtual AspNetUser? UpdatedByNavigation { get; set; }
}
