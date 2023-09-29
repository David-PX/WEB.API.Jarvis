﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Jarvis.WEB.API.Migrations
{
    /// <inheritdoc />
    public partial class CreateAllRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
