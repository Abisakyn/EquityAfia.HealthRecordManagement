using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EquityAfia.HealthRecordManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class HealthRecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HealthRecords",
                columns: table => new
                {
                    HealthRecordsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Systolic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diastolic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthRecords", x => x.HealthRecordsId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HealthRecords");
        }
    }
}
