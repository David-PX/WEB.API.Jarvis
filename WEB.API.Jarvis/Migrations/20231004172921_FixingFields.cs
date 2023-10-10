using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Jarvis.WEB.API.Migrations
{
    /// <inheritdoc />
    public partial class FixingFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "16130925-ad38-4e96-b20d-ff9e8a00fbf5", "1", "STUDENT_ADMISSIONS_ADMIN", "STUDENT_ADMISSIONS_ADMIN" },
                    { "6c21e46d-0b71-4bc0-acd5-23eb145d6483", "1", "EMPLOYEE_ADMISSIONS_ADMIN", "EMPLOYEE_ADMISSIONS_ADMIN" },
                    { "704bf758-55c9-45ed-b9b2-24e843b459aa", "1", "FINANTIAL_ADMIN", "FINANTIAL_ADMIN" },
                    { "72003a9a-0b6a-4614-86b8-33696cdabbfd", "1", "MISC_ADMIN", "MISC_ADMIN" },
                    { "d3c0dad0-04a4-4fcf-a1d7-6b50036088f3", "1", "ACEDEMIC_ADMIN", "ACEDEMIC_ADMIN" },
                    { "ed5d8ec5-afae-41bc-b801-465cfa1d7483", "1", "EMPLOYEE", "EMPLOYEE" },
                    { "f3fbfaa0-f8c5-425b-a9a9-0327309a1b7d", "1", "STUDENT", "STUDENT" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d2f5335b-7470-4d43-9440-43c0e0c6ece4",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "397a91c1-6a69-4a89-985c-da5adffa54fc", "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEICoL5XHdKtoZ0Vm1NtQOhUGudpRjnnmQdYREgfEeBJlY14lnDwj5ST1DLcWaxKsrQ==", "932d2dfa-17ea-4225-8664-11293cc7c863" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16130925-ad38-4e96-b20d-ff9e8a00fbf5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c21e46d-0b71-4bc0-acd5-23eb145d6483");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "704bf758-55c9-45ed-b9b2-24e843b459aa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72003a9a-0b6a-4614-86b8-33696cdabbfd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3c0dad0-04a4-4fcf-a1d7-6b50036088f3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed5d8ec5-afae-41bc-b801-465cfa1d7483");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3fbfaa0-f8c5-425b-a9a9-0327309a1b7d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "189a56f5-f0e5-461d-845f-ea5b3bffa654", "1", "STUDENT_ADMISSIONS_ADMIN", "STUDENT_ADMISSIONS_ADMIN" },
                    { "29e68e26-7e9d-476a-84e7-47acf8ec7469", "1", "EMPLOYEE_ADMISSIONS_ADMIN", "EMPLOYEE_ADMISSIONS_ADMIN" },
                    { "470aa80e-717a-465e-a202-dcb53cfb2f17", "1", "FINANTIAL_ADMIN", "FINANTIAL_ADMIN" },
                    { "5a3d0eac-8c09-4416-b013-c7ad41b2fd1e", "1", "MISC_ADMIN", "MISC_ADMIN" },
                    { "92e38e9b-d7a4-4395-9229-0bcd0221534b", "1", "ACEDEMIC_ADMIN", "ACEDEMIC_ADMIN" },
                    { "9af7d6d7-e876-4132-a879-6d70b18ca4e0", "1", "EMPLOYEE", "EMPLOYEE" },
                    { "ede198a3-2698-48f3-acd3-7e8e5804845f", "1", "STUDENT", "STUDENT" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d2f5335b-7470-4d43-9440-43c0e0c6ece4",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aa91c0d3-40d7-4796-ae2b-60ac61fe55b2", "ADMIN@admin.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEAdqMWfMv0SAghw67AHg+0HGeCYnCgOAG6XaaGwAsEvD2HjG2M7PmjJUGQNPBhG+sg==", "6717e4f8-d193-4cc5-a31e-a18966481de3" });
        }
    }
}
