using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Jarvis.WEB.API.Migrations
{
    /// <inheritdoc />
    public partial class GeneralAdminUserAddMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02e10b3c-d03a-4bf4-bb6f-664c12333c56");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1742be83-c64c-4bea-8126-32de63af6af4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "389d7c17-7fd0-475a-9a75-a77dc6268615");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73a1adc5-8708-4c71-833f-63b9f385aa04");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e800f1f-043d-495f-a514-e485cc092d02");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92a6fd40-6a87-4245-858d-754ec0a5c9b0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e46b1244-04c9-4852-8da9-99417b901eae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6200524-5c2a-46d5-996e-b128c4a82fcc");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "02e10b3c-d03a-4bf4-bb6f-664c12333c56", "1", "GENERAL_ADMIN", "GENERAL_ADMIN" },
                    { "1742be83-c64c-4bea-8126-32de63af6af4", "1", "STUDENT_ADMISSIONS_ADMIN", "STUDENT_ADMISSIONS_ADMIN" },
                    { "389d7c17-7fd0-475a-9a75-a77dc6268615", "1", "STUDENT", "STUDENT" },
                    { "73a1adc5-8708-4c71-833f-63b9f385aa04", "1", "ACEDEMIC_ADMIN", "ACEDEMIC_ADMIN" },
                    { "7e800f1f-043d-495f-a514-e485cc092d02", "1", "FINANTIAL_ADMIN", "FINANTIAL_ADMIN" },
                    { "92a6fd40-6a87-4245-858d-754ec0a5c9b0", "1", "EMPLOYEE", "EMPLOYEE" },
                    { "e46b1244-04c9-4852-8da9-99417b901eae", "1", "MISC_ADMIN", "MISC_ADMIN" },
                    { "f6200524-5c2a-46d5-996e-b128c4a82fcc", "1", "EMPLOYEE_ADMISSIONS_ADMIN", "EMPLOYEE_ADMISSIONS_ADMIN" }
                });
        }
    }
}
