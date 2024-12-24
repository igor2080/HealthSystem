using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthSystem.Migrations
{
    /// <inheritdoc />
    public partial class MedicalInfo_SecondaryValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "SecondaryValue",
                table: "MedicalInformation",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.UpdateData(
                table: "InformationType",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "Resting Heart Rate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SecondaryValue",
                table: "MedicalInformation");

            migrationBuilder.UpdateData(
                table: "InformationType",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "Heart Rate");
        }
    }
}
