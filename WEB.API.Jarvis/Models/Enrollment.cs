using System;
using System.Collections.Generic;

namespace Jarvis.WEB.API.Models;

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

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public string? DeletedBy { get; set; }

    public string? Email { get; set; }

    public bool? IsAdmitted { get; set; }

    public Guid? CareerId { get; set; }

    public virtual Career? Career { get; set; }

    public virtual City? City { get; set; }

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual ICollection<EmergencyContact> EmergencyContacts { get; set; } = new List<EmergencyContact>();

    public virtual IdentificationType? IdentificationType { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
