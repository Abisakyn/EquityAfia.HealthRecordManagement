using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EquityAfia.HealthRecordManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LabResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Test = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Results = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prescriptions = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TestImagePath = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ResultsImagePath = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabResults", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LabResults");
        }
    }
}
