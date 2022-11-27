using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorFullStackCrud.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Wards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Wards_WardId",
                        column: x => x.WardId,
                        principalTable: "Wards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Wards",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "General" });

            migrationBuilder.InsertData(
                table: "Wards",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "ICU" });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "WardId", "FirstName", "Specialization", "LastName" },
                values: new object[] { 1, 1, "Sukesh", "General Anesthesia", "D" });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "WardId", "FirstName", "Specialization", "LastName" },
                values: new object[] { 2, 2, "Madhu", "Orthopaedics", "Pilli" });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_WardId",
                table: "Doctors",
                column: "WardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Wards");
        }
    }
}
