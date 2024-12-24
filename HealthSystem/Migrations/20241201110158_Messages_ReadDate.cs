using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthSystem.Migrations
{
    /// <inheritdoc />
    public partial class Messages_ReadDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ReadDate",
                table: "Message",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReadDate",
                table: "Message");
        }
    }
}
