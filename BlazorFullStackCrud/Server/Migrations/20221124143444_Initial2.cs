using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorFullStackCrud.Server.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FirstName", "LastName", "Specialization" },
                values: new object[] { "Sukesh", "D", "General Anesthesia" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FirstName", "LastName", "Specialization" },
                values: new object[] { "Madhu", "Pilli", "Orthopaedics" });

            migrationBuilder.UpdateData(
                table: "Wards",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "General");

            migrationBuilder.UpdateData(
                table: "Wards",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "ICU");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FirstName", "LastName", "Specialization" },
                values: new object[] { "Peter", "Parker", "Spiderman" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FirstName", "LastName", "Specialization" },
                values: new object[] { "Bruce", "Wayne", "Batman" });

            migrationBuilder.UpdateData(
                table: "Wards",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Marvel");

            migrationBuilder.UpdateData(
                table: "Wards",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "DC");
        }
    }
}
