using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EquityAfia.HealthRecordManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedPatientsDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "HealthRecords",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "HealthRecords",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "HealthRecords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "HealthRecords");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "HealthRecords");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "HealthRecords");
        }
    }
}
