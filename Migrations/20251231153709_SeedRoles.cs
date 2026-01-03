using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Security_Feature_Project.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "PasswordHash", "RoleId", "Username" },
                values: new object[] { 1, new DateTime(2025, 12, 31, 17, 29, 34, 205, DateTimeKind.Local).AddTicks(7633), "$2a$11$QYy2GazmfYYUe/eW/7X/venURyuMLaD6k11X0ctzDZauIVf4qIdau", 1, "admin" });
        }
    }
}
