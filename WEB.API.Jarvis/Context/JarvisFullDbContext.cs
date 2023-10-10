using System;
using System.Collections.Generic;
using Jarvis.WEB.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Jarvis.WEB.API.Context;

public partial class JarvisFullDbContext : DbContext
{
    public JarvisFullDbContext()
    {
    }

    public JarvisFullDbContext(DbContextOptions<JarvisFullDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AcademicArea> AcademicAreas { get; set; }

    public virtual DbSet<AcademicStatus> AcademicStatuses { get; set; }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<AttendanceStudent> AttendanceStudents { get; set; }

    public virtual DbSet<Building> Buildings { get; set; }

    public virtual DbSet<Career> Careers { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Classroom> Classrooms { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<DocumentsType> DocumentsTypes { get; set; }

    public virtual DbSet<EmergencyContact> EmergencyContacts { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeesSchedule> EmployeesSchedules { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<Fee> Fees { get; set; }

    public virtual DbSet<FeeType> FeeTypes { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<GradeStudent> GradeStudents { get; set; }

    public virtual DbSet<GradesType> GradesTypes { get; set; }

    public virtual DbSet<IdentificationType> IdentificationTypes { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<InvoicesStatus> InvoicesStatuses { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<RequestInvoice> RequestInvoices { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<SectionSchedule> SectionSchedules { get; set; }

    public virtual DbSet<SectionStudent> SectionStudents { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentAttendanceStatus> StudentAttendanceStatuses { get; set; }

    public virtual DbSet<StudentsCareer> StudentsCareers { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<SubjectsType> SubjectsTypes { get; set; }

    public virtual DbSet<Trimester> Trimesters { get; set; }

    public virtual DbSet<TrimesterDate> TrimesterDates { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:ConnStr");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AcademicArea>(entity =>
        {
            entity.HasKey(e => e.AcademicAreaId).HasName("PK__Academic__E0B1FCC625CB8A01");

            entity.ToTable("AcademicArea");

            entity.Property(e => e.AcademicAreaId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("AcademicAreaID");
            entity.Property(e => e.AcademicAreaName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(450);
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<AcademicStatus>(entity =>
        {
            entity.HasKey(e => e.AcademicStatusId).HasName("PK__Academic__03A54F7A2E8BE5A1");

            entity.ToTable("AcademicStatus");

            entity.Property(e => e.AcademicStatusId)
                .ValueGeneratedNever()
                .HasColumnName("AcademicStatusID");
            entity.Property(e => e.AcademicStateName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(450);
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => e.AttendanceId).HasName("PK__Attendan__8B69263C70DF051D");

            entity.Property(e => e.AttendanceId)
                .ValueGeneratedNever()
                .HasColumnName("AttendanceID");
            entity.Property(e => e.AttendanceDay).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(450);
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.SectionId).HasColumnName("SectionID");
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Section).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.SectionId)
                .HasConstraintName("FK_Attendances_SectionID");
        });

        modelBuilder.Entity<AttendanceStudent>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("AttendanceStudent");

            entity.HasIndex(e => new { e.AttendanceId, e.StudentId }, "PK_FK_AttendanceStudent");

            entity.Property(e => e.AttendanceId).HasColumnName("AttendanceID");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(450);
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.Observations)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.StudentId)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("StudentID");
            entity.Property(e => e.StudentsAttendanceStatusId).HasColumnName("StudentsAttendanceStatusID");
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Attendance).WithMany()
                .HasForeignKey(d => d.AttendanceId)
                .HasConstraintName("FK_AttendanceStudent_AttendanceID");

            entity.HasOne(d => d.Student).WithMany()
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_AttendanceStudent_StudentID");

            entity.HasOne(d => d.StudentsAttendanceStatus).WithMany()
                .HasForeignKey(d => d.StudentsAttendanceStatusId)
                .HasConstraintName("FK_AttendanceStudent_StudentsAttendanceStatusID");
        });

        modelBuilder.Entity<Building>(entity =>
        {
            entity.HasKey(e => e.BuildingId).HasName("PK__Building__5463CDE46F54B2C2");

            entity.Property(e => e.BuildingId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("BuildingID");
            entity.Property(e => e.BuildingName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(450);
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.Location)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Career>(entity =>
        {
            entity.HasKey(e => e.CareerId).HasName("PK__Careers__A4D2D617A8CF06C4");

            entity.Property(e => e.CareerId)
                .ValueGeneratedNever()
                .HasColumnName("CareerID");
            entity.Property(e => e.AcademicAreaId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("AcademicAreaID");
            entity.Property(e => e.CareerName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(450);
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.AcademicArea).WithMany(p => p.Careers)
                .HasForeignKey(d => d.AcademicAreaId)
                .HasConstraintName("FK_Careers_AcademicAreaID");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PK__Cities__F2D21A96926884DC");

            entity.Property(e => e.CityId)
                .ValueGeneratedNever()
                .HasColumnName("CityID");
            entity.Property(e => e.CityName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(450);
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Country).WithMany(p => p.Cities)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_Cities_CountryID");
        });

        modelBuilder.Entity<Classroom>(entity =>
        {
            entity.HasKey(e => e.ClassroomId).HasName("PK__Classroo__11618E8A980B2361");

            entity.Property(e => e.ClassroomId)
                .ValueGeneratedNever()
                .HasColumnName("ClassroomID");
            entity.Property(e => e.BuildingId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("BuildingID");
            entity.Property(e => e.ClassroomName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(450);
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Building).WithMany(p => p.Classrooms)
                .HasForeignKey(d => d.BuildingId)
                .HasConstraintName("FK_Classrooms_BuildingID");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PK__Countrie__10D160BFB947C9B6");

            entity.Property(e => e.CountryId)
                .ValueGeneratedNever()
                .HasColumnName("CountryID");
            entity.Property(e => e.CountryName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(450);
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.DocumentId).HasName("PK__Document__1ABEEF6FC0BC7DB1");

            entity.Property(e => e.DocumentId)
                .ValueGeneratedNever()
                .HasColumnName("DocumentID");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(450);
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");
            entity.Property(e => e.EnrollmentId).HasColumnName("EnrollmentID");
            entity.Property(e => e.Path).IsUnicode(false);
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.DocumentType).WithMany(p => p.Documents)
                .HasForeignKey(d => d.DocumentTypeId)
                .HasConstraintName("FK_Documents_DocumentTypeID");

            entity.HasOne(d => d.Enrollment).WithMany(p => p.Documents)
                .HasForeignKey(d => d.EnrollmentId)
                .HasConstraintName("FK_Documents_EnrollmentID");
        });

        modelBuilder.Entity<DocumentsType>(entity =>
        {
            entity.HasKey(e => e.DocumentTypeId).HasName("PK__Document__DBA390C101E1ECD5");

            entity.ToTable("DocumentsType");

            entity.Property(e => e.DocumentTypeId)
                .ValueGeneratedNever()
                .HasColumnName("DocumentTypeID");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(450);
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.DocumentTypeName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<EmergencyContact>(entity =>
        {
            entity.HasKey(e => e.EmergencyContactsId).HasName("PK__Emergenc__9CBC307420B17D53");

            entity.Property(e => e.EmergencyContactsId)
                .ValueGeneratedNever()
                .HasColumnName("EmergencyContactsID");
            entity.Property(e => e.Address)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(450);
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.EnrollmentId).HasColumnName("EnrollmentID");
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.RelationShip)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Enrollment).WithMany(p => p.EmergencyContacts)
                .HasForeignKey(d => d.EnrollmentId)
                .HasConstraintName("FK_EmergencyContacts_EnrollmentID");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04FF12552907C");

            entity.Property(e => e.EmployeeId)
                .ValueGeneratedNever()
                .HasColumnName("EmployeeID");
            entity.Property(e => e.AcademicAreaId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("AcademicAreaID");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(450);
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.SupervisorId).HasColumnName("SupervisorID");
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.UserId)
                .HasMaxLength(450)
                .HasColumnName("UserID");

            entity.HasOne(d => d.AcademicArea).WithMany(p => p.Employees)
                .HasForeignKey(d => d.AcademicAreaId)
                .HasConstraintName("FK_Employees_AcademicAreaID");

            entity.HasOne(d => d.Supervisor).WithMany(p => p.InverseSupervisor)
                .HasForeignKey(d => d.SupervisorId)
                .HasConstraintName("FK_Employees_SupervisorID");
        });

        modelBuilder.Entity<EmployeesSchedule>(entity =>
        {
            entity.HasKey(e => e.EmployeesSchedulesId).HasName("PK__Employee__0ECB700BF925F1C8");

            entity.Property(e => e.EmployeesSchedulesId)
                .ValueGeneratedNever()
                .HasColumnName("EmployeesSchedulesID");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Day).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(450);
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.EndHour)
                .HasColumnType("datetime")
                .HasColumnName("endHour");
            entity.Property(e => e.StartHour)
                .HasColumnType("datetime")
                .HasColumnName("startHour");
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeesSchedules)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_EmployeesSchedules_EmployeeID");
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => e.EnrollmentId).HasName("PK__Enrollme__7F6877FB2C3057A0");

            entity.Property(e => e.EnrollmentId)
                .ValueGeneratedNever()
                .HasColumnName("EnrollmentID");
            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(450);
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.Gender)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.IdentificationNumber)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.IdentificationTypeId).HasColumnName("IdentificationTypeID");
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.City).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK_Enrollments_CityID");

            entity.HasOne(d => d.IdentificationType).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.IdentificationTypeId)
                .HasConstraintName("FK_Enrollments_IdentificationTypeID");
        });

        modelBuilder.Entity<Fee>(entity =>
        {
            entity.HasKey(e => e.FeeId).HasName("PK__Fees__B387B2093B5B947F");

            entity.Property(e => e.FeeId)
                .ValueGeneratedNever()
                .HasColumnName("FeeID");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(450);
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.FeeName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.FeeTypeId).HasColumnName("FeeTypeID");
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.FeeType).WithMany(p => p.Fees)
                .HasForeignKey(d => d.FeeTypeId)
                .HasConstraintName("FK_Fees_FeeTypeID");
        });

        modelBuilder.Entity<FeeType>(entity =>
        {
            entity.HasKey(e => e.FeeTypeId).HasName("PK__FeeTypes__D276A58060352B1B");

            entity.Property(e => e.FeeTypeId)
                .ValueGeneratedNever()
                .HasColumnName("FeeTypeID");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(450);
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.FeeTypeName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.GradeId).HasName("PK__Grades__54F87A37B08641C3");

            entity.Property(e => e.GradeId)
                .ValueGeneratedNever()
                .HasColumnName("GradeID");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(450);
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.GradeTypeId).HasColumnName("GradeTypeID");
            entity.Property(e => e.SectionId).HasColumnName("SectionID");
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.GradeType).WithMany(p => p.Grades)
                .HasForeignKey(d => d.GradeTypeId)
                .HasConstraintName("FK_Grades_GradeTypeID");

            entity.HasOne(d => d.Section).WithMany(p => p.Grades)
                .HasForeignKey(d => d.SectionId)
                .HasConstraintName("FK_Grades_SectionID");
        });

        modelBuilder.Entity<GradeStudent>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("GradeStudent");

            entity.HasIndex(e => new { e.GradeId, e.StudentId }, "PK_FK_GradeStudent");

            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(450);
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.GradeId).HasColumnName("GradeID");
            entity.Property(e => e.StudentId)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("StudentID");
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.GradeNavigation).WithMany()
                .HasForeignKey(d => d.GradeId)
                .HasConstraintName("FK_GradeStudent_GradeID");

            entity.HasOne(d => d.Student).WithMany()
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_GradeStudent_StudentID");
        });

        modelBuilder.Entity<GradesType>(entity =>
        {
            entity.HasKey(e => e.GradeTypeId).HasName("PK__GradesTy__314515D9C24D6EED");

            entity.Property(e => e.GradeTypeId)
                .ValueGeneratedNever()
                .HasColumnName("GradeTypeID");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(450);
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.GradeTypeName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<IdentificationType>(entity =>
        {
            entity.HasKey(e => e.IdentificationTypeId).HasName("PK__Identifi__B8F30D285A5FCAB5");

            entity.ToTable("IdentificationType");

            entity.Property(e => e.IdentificationTypeId)
                .ValueGeneratedNever()
                .HasColumnName("IdentificationTypeID");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(450);
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.IdentificationTypeName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Length)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.InvoiceId).HasName("PK__Invoices__D796AAD537B950E0");

            entity.Property(e => e.InvoiceId)
                .ValueGeneratedNever()
                .HasColumnName("InvoiceID");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(450);
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.InvoiceStatusId).HasColumnName("InvoiceStatusID");
            entity.Property(e => e.StudentId)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("StudentID");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.InvoiceStatus).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.InvoiceStatusId)
                .HasConstraintName("FK_Invoices_InvoiceStatusID");

            entity.HasOne(d => d.Student).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_Invoices_StudentID");
        });

        modelBuilder.Entity<InvoicesStatus>(entity =>
        {
            entity.HasKey(e => e.InvoiceStatusId).HasName("PK__Invoices__E6341E30D4791538");

            entity.ToTable("InvoicesStatus");

            entity.Property(e => e.InvoiceStatusId)
                .ValueGeneratedNever()
                .HasColumnName("InvoiceStatusID");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(450);
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.InvoiceStatusName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payments__9B556A58E2F3BCD6");

            entity.Property(e => e.PaymentId)
                .ValueGeneratedNever()
                .HasColumnName("PaymentID");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(450);
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Invoice).WithMany(p => p.Payments)
                .HasForeignKey(d => d.InvoiceId)
                .HasConstraintName("FK_Payments_InvoiceID");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.ReportId).HasName("PK__Reports__D5BD48E5C98B3CF1");

            entity.Property(e => e.ReportId)
                .ValueGeneratedNever()
                .HasColumnName("ReportID");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(450);
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.SectionId).HasColumnName("SectionID");
            entity.Property(e => e.StudentId)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("StudentID");
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Section).WithMany(p => p.Reports)
                .HasForeignKey(d => d.SectionId)
                .HasConstraintName("FK_Reports_SectionID");

            entity.HasOne(d => d.Student).WithMany(p => p.Reports)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_Reports_StudentID");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__Request__33A8519A3303FBFD");

            entity.ToTable("Request");

            entity.Property(e => e.RequestId)
                .ValueGeneratedNever()
                .HasColumnName("RequestID");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(450);
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.FeeId).HasColumnName("FeeID");
            entity.Property(e => e.RequestDate).HasColumnType("datetime");
            entity.Property(e => e.StudentId)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("StudentID");
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Fee).WithMany(p => p.Requests)
                .HasForeignKey(d => d.FeeId)
                .HasConstraintName("FK_Request_FeeID");

            entity.HasOne(d => d.Student).WithMany(p => p.Requests)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_Request_StudentID");
        });

        modelBuilder.Entity<RequestInvoice>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RequestInvoice");

            entity.HasIndex(e => new { e.InvoiceId, e.RequestId }, "PK_FK_RequestInvoice");

            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(450);
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.FeeAmount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");
            entity.Property(e => e.RequestId).HasColumnName("RequestID");
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Invoice).WithMany()
                .HasForeignKey(d => d.InvoiceId)
                .HasConstraintName("FK_RequestInvoice_InvoiceID");

            entity.HasOne(d => d.Request).WithMany()
                .HasForeignKey(d => d.RequestId)
                .HasConstraintName("FK_RequestInvoice_RequestID");
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.HasKey(e => e.SectionId).HasName("PK__Sections__80EF0892398AF5F1");

            entity.Property(e => e.SectionId)
                .ValueGeneratedNever()
                .HasColumnName("SectionID");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(450);
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.StartTime).HasColumnType("datetime");
            entity.Property(e => e.SubjectId)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("SubjectID");
            entity.Property(e => e.TeacherId).HasColumnName("TeacherID");
            entity.Property(e => e.TrimesterId).HasColumnName("TrimesterID");
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Subject).WithMany(p => p.Sections)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK_Sections_SubjectID");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Sections)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK_Sections_TeacherID");

            entity.HasOne(d => d.Trimester).WithMany(p => p.Sections)
                .HasForeignKey(d => d.TrimesterId)
                .HasConstraintName("FK_Sections_TrimesterID");
        });

        modelBuilder.Entity<SectionSchedule>(entity =>
        {
            entity.HasKey(e => e.SectionScheduleId).HasName("PK__SectionS__979C1B87FA2F6507");

            entity.Property(e => e.SectionScheduleId)
                .ValueGeneratedNever()
                .HasColumnName("SectionScheduleID");
            entity.Property(e => e.ClassroomId).HasColumnName("ClassroomID");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Day)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.DeletedBy).HasMaxLength(450);
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.EndHour)
                .HasColumnType("datetime")
                .HasColumnName("endHour");
            entity.Property(e => e.SectionId).HasColumnName("SectionID");
            entity.Property(e => e.StartHour)
                .HasColumnType("datetime")
                .HasColumnName("startHour");
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Classroom).WithMany(p => p.SectionSchedules)
                .HasForeignKey(d => d.ClassroomId)
                .HasConstraintName("FK_SectionSchedules_ClassroomID");

            entity.HasOne(d => d.Section).WithMany(p => p.SectionSchedules)
                .HasForeignKey(d => d.SectionId)
                .HasConstraintName("FK_SectionSchedules_SectionID");
        });

        modelBuilder.Entity<SectionStudent>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SectionStudent");

            entity.HasIndex(e => new { e.SectionId, e.StudentId }, "PK_FK_SectionStudent");

            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(450);
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.SectionId).HasColumnName("SectionID");
            entity.Property(e => e.StudentId)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("StudentID");
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Section).WithMany()
                .HasForeignKey(d => d.SectionId)
                .HasConstraintName("FK_SectionStudent_SectionID");

            entity.HasOne(d => d.Student).WithMany()
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_SectionStudent_StudentID");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Students__32C52A7944FEB621");

            entity.Property(e => e.StudentId)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("StudentID");
            entity.Property(e => e.AcademicStatusId).HasColumnName("AcademicStatusID");
            entity.Property(e => e.CareerId).HasColumnName("CareerID");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(450);
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.EnrollmentId).HasColumnName("EnrollmentID");
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.UserId)
                .HasMaxLength(450)
                .HasColumnName("UserID");

            entity.HasOne(d => d.AcademicStatus).WithMany(p => p.Students)
                .HasForeignKey(d => d.AcademicStatusId)
                .HasConstraintName("FK_Students_AcademicStatusID");

            entity.HasOne(d => d.Career).WithMany(p => p.Students)
                .HasForeignKey(d => d.CareerId)
                .HasConstraintName("FK_Students_CareerID");

            entity.HasOne(d => d.Enrollment).WithMany(p => p.Students)
                .HasForeignKey(d => d.EnrollmentId)
                .HasConstraintName("FK_Students_EnrollmentID");
        });

        modelBuilder.Entity<StudentAttendanceStatus>(entity =>
        {
            entity.HasKey(e => e.StudentAttendanceStatusId).HasName("PK__StudentA__7A8008C26D618645");

            entity.ToTable("StudentAttendanceStatus");

            entity.Property(e => e.StudentAttendanceStatusId)
                .ValueGeneratedNever()
                .HasColumnName("StudentAttendanceStatusID");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(450);
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.StudentAttendanceStatusName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<StudentsCareer>(entity =>
        {
            entity.HasNoKey();

            entity.HasIndex(e => new { e.StudentId, e.CareerId }, "PK_FK_StudentsCareers");

            entity.Property(e => e.CareerId).HasColumnName("CareerID");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(450);
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.StudentId)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("StudentID");
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Career).WithMany()
                .HasForeignKey(d => d.CareerId)
                .HasConstraintName("FK_StudentsCareers_CareerID");

            entity.HasOne(d => d.Student).WithMany()
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_StudentsCareers_StudentID");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("PK__Subjects__AC1BA38852134410");

            entity.Property(e => e.SubjectId)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("SubjectID");
            entity.Property(e => e.AcademicAreaId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("AcademicAreaID");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(450);
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.SubjectName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.SubjectTypeId).HasColumnName("SubjectTypeID");
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.AcademicArea).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.AcademicAreaId)
                .HasConstraintName("FK_Subjects_AcademicAreaID");

            entity.HasOne(d => d.SubjectType).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.SubjectTypeId)
                .HasConstraintName("FK_Subjects_SubjectTypeID");
        });

        modelBuilder.Entity<SubjectsType>(entity =>
        {
            entity.HasKey(e => e.SubjectTypeId).HasName("PK__Subjects__AE50BCF2E53A8D52");

            entity.Property(e => e.SubjectTypeId)
                .ValueGeneratedNever()
                .HasColumnName("SubjectTypeID");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(450);
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.SubjectTypeName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Trimester>(entity =>
        {
            entity.HasKey(e => e.IdTrimestres).HasName("PK__Trimeste__D3D84AF734370C0B");

            entity.ToTable("Trimester");

            entity.Property(e => e.IdTrimestres).ValueGeneratedNever();
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(450);
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TrimesterDate>(entity =>
        {
            entity.HasKey(e => e.TrimesterDateId).HasName("PK__Trimeste__2FF57BDE7A79BB1C");

            entity.Property(e => e.TrimesterDateId)
                .ValueGeneratedNever()
                .HasColumnName("TrimesterDateID");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(450);
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.TrimesterDateName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.TrimesterId).HasColumnName("TrimesterID");
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Trimester).WithMany(p => p.TrimesterDates)
                .HasForeignKey(d => d.TrimesterId)
                .HasConstraintName("FK_TrimesterDates_TrimesterID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
