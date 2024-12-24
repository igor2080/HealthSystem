using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HealthSystem.Migrations
{
    /// <inheritdoc />
    public partial class InformationType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Information_Type",
                table: "MedicalInformation");

            migrationBuilder.AddColumn<int>(
                name: "InformationTypeId",
                table: "MedicalInformation",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "InformationType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformationType", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "InformationType",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Waist Size" },
                    { 2, "Blood Pressure" },
                    { 3, "Weight" },
                    { 4, "Heart Rate" },
                    { 5, "CGM" },
                    { 6, "Insulin" },
                    { 7, "Triglyceride" },
                    { 8, "HDL Cholesterol" },
                    { 9, "LDL Cholesterol" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicalInformation_InformationTypeId",
                table: "MedicalInformation",
                column: "InformationTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalInformation_InformationType_InformationTypeId",
                table: "MedicalInformation",
                column: "InformationTypeId",
                principalTable: "InformationType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalInformation_InformationType_InformationTypeId",
                table: "MedicalInformation");

            migrationBuilder.DropTable(
                name: "InformationType");

            migrationBuilder.DropIndex(
                name: "IX_MedicalInformation_InformationTypeId",
                table: "MedicalInformation");

            migrationBuilder.DropColumn(
                name: "InformationTypeId",
                table: "MedicalInformation");

            migrationBuilder.AddColumn<string>(
                name: "Information_Type",
                table: "MedicalInformation",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
