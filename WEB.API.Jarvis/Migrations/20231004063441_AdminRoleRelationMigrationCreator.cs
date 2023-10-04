using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Jarvis.WEB.API.Migrations
{
    /// <inheritdoc />
    public partial class AdminRoleRelationMigrationCreator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0003dd85-a1ac-437e-bf0b-00364ede1f56");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0666d097-6db8-41a2-9905-c5e2b3198470");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "480cbd9c-784a-4cc3-84a9-f20539571e5f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c0f3136-2755-46c4-b69d-792227d070c3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66a17000-d48a-461b-b5d3-491fe83c8488");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6c7ba24-7413-4317-8dba-b42af6f9bd2c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0b574de-cbd0-47d5-bbd5-659349a25fd2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eff703ca-c4b5-4829-936f-50975ec22fcd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cf32c2e6-afa5-41e5-af8e-97d846f70d52");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "189a56f5-f0e5-461d-845f-ea5b3bffa654", "1", "STUDENT_ADMISSIONS_ADMIN", "STUDENT_ADMISSIONS_ADMIN" },
                    { "22b2cec2-4456-4fa5-b429-a499fa098585", "1", "GENERAL_ADMIN", "GENERAL_ADMIN" },
                    { "29e68e26-7e9d-476a-84e7-47acf8ec7469", "1", "EMPLOYEE_ADMISSIONS_ADMIN", "EMPLOYEE_ADMISSIONS_ADMIN" },
                    { "470aa80e-717a-465e-a202-dcb53cfb2f17", "1", "FINANTIAL_ADMIN", "FINANTIAL_ADMIN" },
                    { "5a3d0eac-8c09-4416-b013-c7ad41b2fd1e", "1", "MISC_ADMIN", "MISC_ADMIN" },
                    { "92e38e9b-d7a4-4395-9229-0bcd0221534b", "1", "ACEDEMIC_ADMIN", "ACEDEMIC_ADMIN" },
                    { "9af7d6d7-e876-4132-a879-6d70b18ca4e0", "1", "EMPLOYEE", "EMPLOYEE" },
                    { "ede198a3-2698-48f3-acd3-7e8e5804845f", "1", "STUDENT", "STUDENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d2f5335b-7470-4d43-9440-43c0e0c6ece4", 0, "aa91c0d3-40d7-4796-ae2b-60ac61fe55b2", "admin@admin.com", true, false, null, "ADMIN@admin.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEAdqMWfMv0SAghw67AHg+0HGeCYnCgOAG6XaaGwAsEvD2HjG2M7PmjJUGQNPBhG+sg==", null, false, "6717e4f8-d193-4cc5-a31e-a18966481de3", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "22b2cec2-4456-4fa5-b429-a499fa098585", "d2f5335b-7470-4d43-9440-43c0e0c6ece4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "189a56f5-f0e5-461d-845f-ea5b3bffa654");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29e68e26-7e9d-476a-84e7-47acf8ec7469");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "470aa80e-717a-465e-a202-dcb53cfb2f17");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a3d0eac-8c09-4416-b013-c7ad41b2fd1e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92e38e9b-d7a4-4395-9229-0bcd0221534b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9af7d6d7-e876-4132-a879-6d70b18ca4e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ede198a3-2698-48f3-acd3-7e8e5804845f");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "22b2cec2-4456-4fa5-b429-a499fa098585", "d2f5335b-7470-4d43-9440-43c0e0c6ece4" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22b2cec2-4456-4fa5-b429-a499fa098585");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d2f5335b-7470-4d43-9440-43c0e0c6ece4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0003dd85-a1ac-437e-bf0b-00364ede1f56", "1", "EMPLOYEE_ADMISSIONS_ADMIN", "EMPLOYEE_ADMISSIONS_ADMIN" },
                    { "0666d097-6db8-41a2-9905-c5e2b3198470", "1", "ACEDEMIC_ADMIN", "ACEDEMIC_ADMIN" },
                    { "480cbd9c-784a-4cc3-84a9-f20539571e5f", "1", "STUDENT", "STUDENT" },
                    { "5c0f3136-2755-46c4-b69d-792227d070c3", "1", "GENERAL_ADMIN", "GENERAL_ADMIN" },
                    { "66a17000-d48a-461b-b5d3-491fe83c8488", "1", "EMPLOYEE", "EMPLOYEE" },
                    { "a6c7ba24-7413-4317-8dba-b42af6f9bd2c", "1", "STUDENT_ADMISSIONS_ADMIN", "STUDENT_ADMISSIONS_ADMIN" },
                    { "c0b574de-cbd0-47d5-bbd5-659349a25fd2", "1", "MISC_ADMIN", "MISC_ADMIN" },
                    { "eff703ca-c4b5-4829-936f-50975ec22fcd", "1", "FINANTIAL_ADMIN", "FINANTIAL_ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "cf32c2e6-afa5-41e5-af8e-97d846f70d52", 0, "a92e06d9-16aa-40db-8dd1-44edaa64e321", "admin@admin.com", true, false, null, "ADMIN@admin.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEM68U/SR9XaByjD2PW9y1nec4meLkS/jiW2bMZZ/wAd8OszwMCsIPHpcDYFft8xoKg==", null, false, "db2e75eb-169a-484a-9c6b-45c824d485c2", false, "admin@admin.com" });
        }
    }
}
