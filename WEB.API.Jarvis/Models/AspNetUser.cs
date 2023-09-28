using System;
using System.Collections.Generic;

namespace WEB.API.Jarvis.Models;

public partial class AspNetUser
{
    public string Id { get; set; } = null!;

    public string? UserName { get; set; }

    public string? NormalizedUserName { get; set; }

    public string? Email { get; set; }

    public string? NormalizedEmail { get; set; }

    public bool EmailConfirmed { get; set; }

    public string? PasswordHash { get; set; }

    public string? SecurityStamp { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public string? PhoneNumber { get; set; }

    public bool PhoneNumberConfirmed { get; set; }

    public bool TwoFactorEnabled { get; set; }

    public DateTimeOffset? LockoutEnd { get; set; }

    public bool LockoutEnabled { get; set; }

    public int AccessFailedCount { get; set; }

    public virtual ICollection<AcademicArea> AcademicAreaCreatedByNavigations { get; set; } = new List<AcademicArea>();

    public virtual ICollection<AcademicArea> AcademicAreaDeletedByNavigations { get; set; } = new List<AcademicArea>();

    public virtual ICollection<AcademicArea> AcademicAreaUpdatedByNavigations { get; set; } = new List<AcademicArea>();

    public virtual ICollection<AcademicStatus> AcademicStatusCreatedByNavigations { get; set; } = new List<AcademicStatus>();

    public virtual ICollection<AcademicStatus> AcademicStatusDeletedByNavigations { get; set; } = new List<AcademicStatus>();

    public virtual ICollection<AcademicStatus> AcademicStatusUpdatedByNavigations { get; set; } = new List<AcademicStatus>();

    public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; } = new List<AspNetUserClaim>();

    public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; } = new List<AspNetUserLogin>();

    public virtual ICollection<AspNetUserToken> AspNetUserTokens { get; set; } = new List<AspNetUserToken>();

    public virtual ICollection<Attendance> AttendanceCreatedByNavigations { get; set; } = new List<Attendance>();

    public virtual ICollection<Attendance> AttendanceDeletedByNavigations { get; set; } = new List<Attendance>();

    public virtual ICollection<Attendance> AttendanceUpdatedByNavigations { get; set; } = new List<Attendance>();

    public virtual ICollection<Building> BuildingCreatedByNavigations { get; set; } = new List<Building>();

    public virtual ICollection<Building> BuildingDeletedByNavigations { get; set; } = new List<Building>();

    public virtual ICollection<Building> BuildingUpdatedByNavigations { get; set; } = new List<Building>();

    public virtual ICollection<Career> CareerCreatedByNavigations { get; set; } = new List<Career>();

    public virtual ICollection<Career> CareerDeletedByNavigations { get; set; } = new List<Career>();

    public virtual ICollection<Career> CareerUpdatedByNavigations { get; set; } = new List<Career>();

    public virtual ICollection<City> CityCreatedByNavigations { get; set; } = new List<City>();

    public virtual ICollection<City> CityDeletedByNavigations { get; set; } = new List<City>();

    public virtual ICollection<City> CityUpdatedByNavigations { get; set; } = new List<City>();

    public virtual ICollection<Classroom> ClassroomCreatedByNavigations { get; set; } = new List<Classroom>();

    public virtual ICollection<Classroom> ClassroomDeletedByNavigations { get; set; } = new List<Classroom>();

    public virtual ICollection<Classroom> ClassroomUpdatedByNavigations { get; set; } = new List<Classroom>();

    public virtual ICollection<Country> CountryCreatedByNavigations { get; set; } = new List<Country>();

    public virtual ICollection<Country> CountryDeletedByNavigations { get; set; } = new List<Country>();

    public virtual ICollection<Country> CountryUpdatedByNavigations { get; set; } = new List<Country>();

    public virtual ICollection<Document> DocumentCreatedByNavigations { get; set; } = new List<Document>();

    public virtual ICollection<Document> DocumentDeletedByNavigations { get; set; } = new List<Document>();

    public virtual ICollection<Document> DocumentUpdatedByNavigations { get; set; } = new List<Document>();

    public virtual ICollection<DocumentsType> DocumentsTypeCreatedByNavigations { get; set; } = new List<DocumentsType>();

    public virtual ICollection<DocumentsType> DocumentsTypeDeletedByNavigations { get; set; } = new List<DocumentsType>();

    public virtual ICollection<DocumentsType> DocumentsTypeUpdatedByNavigations { get; set; } = new List<DocumentsType>();

    public virtual ICollection<EmergencyContact> EmergencyContactCreatedByNavigations { get; set; } = new List<EmergencyContact>();

    public virtual ICollection<EmergencyContact> EmergencyContactDeletedByNavigations { get; set; } = new List<EmergencyContact>();

    public virtual ICollection<EmergencyContact> EmergencyContactUpdatedByNavigations { get; set; } = new List<EmergencyContact>();

    public virtual ICollection<Employee> EmployeeCreatedByNavigations { get; set; } = new List<Employee>();

    public virtual ICollection<Employee> EmployeeDeletedByNavigations { get; set; } = new List<Employee>();

    public virtual ICollection<Employee> EmployeeUpdatedByNavigations { get; set; } = new List<Employee>();

    public virtual ICollection<Employee> EmployeeUsers { get; set; } = new List<Employee>();

    public virtual ICollection<EmployeesSchedule> EmployeesScheduleCreatedByNavigations { get; set; } = new List<EmployeesSchedule>();

    public virtual ICollection<EmployeesSchedule> EmployeesScheduleDeletedByNavigations { get; set; } = new List<EmployeesSchedule>();

    public virtual ICollection<EmployeesSchedule> EmployeesScheduleUpdatedByNavigations { get; set; } = new List<EmployeesSchedule>();

    public virtual ICollection<Enrollment> EnrollmentCreatedByNavigations { get; set; } = new List<Enrollment>();

    public virtual ICollection<Enrollment> EnrollmentDeletedByNavigations { get; set; } = new List<Enrollment>();

    public virtual ICollection<Enrollment> EnrollmentUpdatedByNavigations { get; set; } = new List<Enrollment>();

    public virtual ICollection<Fee> FeeCreatedByNavigations { get; set; } = new List<Fee>();

    public virtual ICollection<Fee> FeeDeletedByNavigations { get; set; } = new List<Fee>();

    public virtual ICollection<FeeType> FeeTypeCreatedByNavigations { get; set; } = new List<FeeType>();

    public virtual ICollection<FeeType> FeeTypeDeletedByNavigations { get; set; } = new List<FeeType>();

    public virtual ICollection<FeeType> FeeTypeUpdatedByNavigations { get; set; } = new List<FeeType>();

    public virtual ICollection<Fee> FeeUpdatedByNavigations { get; set; } = new List<Fee>();

    public virtual ICollection<Grade> GradeCreatedByNavigations { get; set; } = new List<Grade>();

    public virtual ICollection<Grade> GradeDeletedByNavigations { get; set; } = new List<Grade>();

    public virtual ICollection<Grade> GradeUpdatedByNavigations { get; set; } = new List<Grade>();

    public virtual ICollection<GradesType> GradesTypeCreatedByNavigations { get; set; } = new List<GradesType>();

    public virtual ICollection<GradesType> GradesTypeDeletedByNavigations { get; set; } = new List<GradesType>();

    public virtual ICollection<GradesType> GradesTypeUpdatedByNavigations { get; set; } = new List<GradesType>();

    public virtual ICollection<IdentificationType> IdentificationTypeCreatedByNavigations { get; set; } = new List<IdentificationType>();

    public virtual ICollection<IdentificationType> IdentificationTypeDeletedByNavigations { get; set; } = new List<IdentificationType>();

    public virtual ICollection<IdentificationType> IdentificationTypeUpdatedByNavigations { get; set; } = new List<IdentificationType>();

    public virtual ICollection<Invoice> InvoiceCreatedByNavigations { get; set; } = new List<Invoice>();

    public virtual ICollection<Invoice> InvoiceDeletedByNavigations { get; set; } = new List<Invoice>();

    public virtual ICollection<Invoice> InvoiceUpdatedByNavigations { get; set; } = new List<Invoice>();

    public virtual ICollection<InvoicesStatus> InvoicesStatusCreatedByNavigations { get; set; } = new List<InvoicesStatus>();

    public virtual ICollection<InvoicesStatus> InvoicesStatusDeletedByNavigations { get; set; } = new List<InvoicesStatus>();

    public virtual ICollection<InvoicesStatus> InvoicesStatusUpdatedByNavigations { get; set; } = new List<InvoicesStatus>();

    public virtual ICollection<Payment> PaymentCreatedByNavigations { get; set; } = new List<Payment>();

    public virtual ICollection<Payment> PaymentDeletedByNavigations { get; set; } = new List<Payment>();

    public virtual ICollection<Payment> PaymentUpdatedByNavigations { get; set; } = new List<Payment>();

    public virtual ICollection<Report> ReportCreatedByNavigations { get; set; } = new List<Report>();

    public virtual ICollection<Report> ReportDeletedByNavigations { get; set; } = new List<Report>();

    public virtual ICollection<Report> ReportUpdatedByNavigations { get; set; } = new List<Report>();

    public virtual ICollection<Request> RequestCreatedByNavigations { get; set; } = new List<Request>();

    public virtual ICollection<Request> RequestDeletedByNavigations { get; set; } = new List<Request>();

    public virtual ICollection<Request> RequestUpdatedByNavigations { get; set; } = new List<Request>();

    public virtual ICollection<Section> SectionCreatedByNavigations { get; set; } = new List<Section>();

    public virtual ICollection<Section> SectionDeletedByNavigations { get; set; } = new List<Section>();

    public virtual ICollection<SectionSchedule> SectionScheduleCreatedByNavigations { get; set; } = new List<SectionSchedule>();

    public virtual ICollection<SectionSchedule> SectionScheduleDeletedByNavigations { get; set; } = new List<SectionSchedule>();

    public virtual ICollection<SectionSchedule> SectionScheduleUpdatedByNavigations { get; set; } = new List<SectionSchedule>();

    public virtual ICollection<Section> SectionUpdatedByNavigations { get; set; } = new List<Section>();

    public virtual ICollection<StudentAttendanceStatus> StudentAttendanceStatusCreatedByNavigations { get; set; } = new List<StudentAttendanceStatus>();

    public virtual ICollection<StudentAttendanceStatus> StudentAttendanceStatusDeletedByNavigations { get; set; } = new List<StudentAttendanceStatus>();

    public virtual ICollection<StudentAttendanceStatus> StudentAttendanceStatusUpdatedByNavigations { get; set; } = new List<StudentAttendanceStatus>();

    public virtual ICollection<Student> StudentCreatedByNavigations { get; set; } = new List<Student>();

    public virtual ICollection<Student> StudentDeletedByNavigations { get; set; } = new List<Student>();

    public virtual ICollection<Student> StudentUpdatedByNavigations { get; set; } = new List<Student>();

    public virtual ICollection<Student> StudentUsers { get; set; } = new List<Student>();

    public virtual ICollection<Subject> SubjectCreatedByNavigations { get; set; } = new List<Subject>();

    public virtual ICollection<Subject> SubjectDeletedByNavigations { get; set; } = new List<Subject>();

    public virtual ICollection<Subject> SubjectUpdatedByNavigations { get; set; } = new List<Subject>();

    public virtual ICollection<SubjectsType> SubjectsTypeCreatedByNavigations { get; set; } = new List<SubjectsType>();

    public virtual ICollection<SubjectsType> SubjectsTypeDeletedByNavigations { get; set; } = new List<SubjectsType>();

    public virtual ICollection<SubjectsType> SubjectsTypeUpdatedByNavigations { get; set; } = new List<SubjectsType>();

    public virtual ICollection<Trimester> TrimesterCreatedByNavigations { get; set; } = new List<Trimester>();

    public virtual ICollection<TrimesterDate> TrimesterDateCreatedByNavigations { get; set; } = new List<TrimesterDate>();

    public virtual ICollection<TrimesterDate> TrimesterDateDeletedByNavigations { get; set; } = new List<TrimesterDate>();

    public virtual ICollection<TrimesterDate> TrimesterDateUpdatedByNavigations { get; set; } = new List<TrimesterDate>();

    public virtual ICollection<Trimester> TrimesterDeletedByNavigations { get; set; } = new List<Trimester>();

    public virtual ICollection<Trimester> TrimesterUpdatedByNavigations { get; set; } = new List<Trimester>();

    public virtual ICollection<AspNetRole> Roles { get; set; } = new List<AspNetRole>();
}
