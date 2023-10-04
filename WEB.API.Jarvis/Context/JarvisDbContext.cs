using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.IsisMtt.X509;
using WEB.API.Jarvis.Models;

namespace WEB.API.Jarvis.Context;

public partial class JarvisDbContext : IdentityDbContext<IdentityUser>
{
   
    public JarvisDbContext(DbContextOptions<JarvisDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        SeedRoles(modelBuilder);
        SeedGeneralAdmin(modelBuilder);
        SeedAdminRoleRelation(modelBuilder);
    }

    private void SeedRoles(ModelBuilder modelBuilder) 
    {
        modelBuilder.Entity<IdentityRole>().HasData (
            new IdentityRole() { Name = "STUDENT", ConcurrencyStamp = "1", NormalizedName = "STUDENT" },
            new IdentityRole() { Name = "EMPLOYEE", ConcurrencyStamp = "1", NormalizedName = "EMPLOYEE" },
            new IdentityRole() { Id = "22b2cec2-4456-4fa5-b429-a499fa098585", Name = "GENERAL_ADMIN", ConcurrencyStamp = "1", NormalizedName = "GENERAL_ADMIN" },
            new IdentityRole() { Name = "STUDENT_ADMISSIONS_ADMIN", ConcurrencyStamp = "1", NormalizedName = "STUDENT_ADMISSIONS_ADMIN" },
            new IdentityRole() { Name = "EMPLOYEE_ADMISSIONS_ADMIN", ConcurrencyStamp = "1", NormalizedName = "EMPLOYEE_ADMISSIONS_ADMIN" },
            new IdentityRole() { Name = "ACEDEMIC_ADMIN", ConcurrencyStamp = "1", NormalizedName = "ACEDEMIC_ADMIN" },
            new IdentityRole() { Name = "FINANTIAL_ADMIN", ConcurrencyStamp = "1", NormalizedName = "FINANTIAL_ADMIN" },
            new IdentityRole() { Name = "MISC_ADMIN", ConcurrencyStamp = "1", NormalizedName = "MISC_ADMIN" }
        );
    }

    private void SeedGeneralAdmin(ModelBuilder modelBuilder)
    {
        var hasher = new PasswordHasher<IdentityUser>();
        modelBuilder.Entity<IdentityUser>().HasData(
            new IdentityUser
            {
                Id = "d2f5335b-7470-4d43-9440-43c0e0c6ece4",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@EXAMPLE.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@admin.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Password123!")
            });
    }

    private void SeedAdminRoleRelation(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "22b2cec2-4456-4fa5-b429-a499fa098585",
                UserId = "d2f5335b-7470-4d43-9440-43c0e0c6ece4",
            });
    }
    
}
