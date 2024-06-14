using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EquityAfia.HealthRecordManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TestImagePath",
                table: "LabResults",
                newName: "TestImage");

            migrationBuilder.RenameColumn(
                name: "ResultsImagePath",
                table: "LabResults",
                newName: "ResultsImage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TestImage",
                table: "LabResults",
                newName: "TestImagePath");

            migrationBuilder.RenameColumn(
                name: "ResultsImage",
                table: "LabResults",
                newName: "ResultsImagePath");
        }
    }
}
