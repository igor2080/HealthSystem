using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthSystem.Migrations
{
    /// <inheritdoc />
    public partial class TriggerParameter_InformationType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "TriggerParameters");

            migrationBuilder.AddColumn<int>(
                name: "InformationTypeId",
                table: "TriggerParameters",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TriggerParameters_InformationTypeId",
                table: "TriggerParameters",
                column: "InformationTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TriggerParameters_InformationType_InformationTypeId",
                table: "TriggerParameters",
                column: "InformationTypeId",
                principalTable: "InformationType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TriggerParameters_InformationType_InformationTypeId",
                table: "TriggerParameters");

            migrationBuilder.DropIndex(
                name: "IX_TriggerParameters_InformationTypeId",
                table: "TriggerParameters");

            migrationBuilder.DropColumn(
                name: "InformationTypeId",
                table: "TriggerParameters");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "TriggerParameters",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
