using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthSystem.Migrations
{
    /// <inheritdoc />
    public partial class TriggerParameter_DynamicsScore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lower_Boundary",
                table: "TriggerParameters");

            migrationBuilder.DropColumn(
                name: "Upper_Boundary",
                table: "TriggerParameters");

            migrationBuilder.AddColumn<int>(
                name: "DynamicsScore",
                table: "TriggerParameters",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DynamicsScore",
                table: "TriggerParameters");

            migrationBuilder.AddColumn<float>(
                name: "Lower_Boundary",
                table: "TriggerParameters",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Upper_Boundary",
                table: "TriggerParameters",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
