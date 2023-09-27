using System;
using System.Collections.Generic;

namespace WEB.API.Jarvis.Models;

public partial class Enrollment
{
    public Guid EnrollmentId { get; set; }

    public string? Name { get; set; }

    public string? LastName { get; set; }

    public DateTime? BirthDate { get; set; }

    public string? Gender { get; set; }

    public Guid? IdentificationTypeId { get; set; }

    public Guid? CityId { get; set; }

    public string? IdentificationNumber { get; set; }

    public string? PhoneNumber { get; set; }

    public string? MobileNumber { get; set; }

    public virtual City? City { get; set; }

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual ICollection<EmergencyContact> EmergencyContacts { get; set; } = new List<EmergencyContact>();

    public virtual IdentificationType? IdentificationType { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
