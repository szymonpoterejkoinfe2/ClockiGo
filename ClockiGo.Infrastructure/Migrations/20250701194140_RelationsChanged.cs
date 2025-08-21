using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClockiGo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RelationsChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserOrganizations_UserId",
                table: "UserOrganizations");

            migrationBuilder.AddColumn<Guid>(
                name: "UserOrganizationId",
                table: "Users",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_UserOrganizations_UserId",
                table: "UserOrganizations",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserOrganizations_UserId",
                table: "UserOrganizations");

            migrationBuilder.DropColumn(
                name: "UserOrganizationId",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrganizations_UserId",
                table: "UserOrganizations",
                column: "UserId");
        }
    }
}
