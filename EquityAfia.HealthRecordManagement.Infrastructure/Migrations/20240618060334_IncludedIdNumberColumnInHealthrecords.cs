using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EquityAfia.HealthRecordManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IncludedIdNumberColumnInHealthrecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdNumber",
                table: "HealthRecords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdNumber",
                table: "HealthRecords");
        }
    }
}
