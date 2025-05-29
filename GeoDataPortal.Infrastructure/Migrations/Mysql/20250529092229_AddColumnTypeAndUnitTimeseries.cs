using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeoDataPortal.Infrastructure.Migrations.Mysql
{
    /// <inheritdoc />
    public partial class AddColumnTypeAndUnitTimeseries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Timeseries",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "Timeseries",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Timeseries");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "Timeseries");
        }
    }
}
