using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClockiGo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Entities_Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Availabilities_UserOrganizations_UserOrganizationId",
                table: "Availabilities");

            migrationBuilder.DropTable(
                name: "UserOrganizations");

            migrationBuilder.RenameColumn(
                name: "UserOrganizationId",
                table: "Users",
                newName: "OrganizationId");

            migrationBuilder.RenameColumn(
                name: "UserOrganizationId",
                table: "Availabilities",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Availabilities_UserOrganizationId",
                table: "Availabilities",
                newName: "IX_Availabilities_UserId");

            migrationBuilder.AddColumn<byte>(
                name: "Role",
                table: "Users",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<Guid>(
                name: "OrganizationId",
                table: "Availabilities",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_OrganizationId",
                table: "Users",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Availabilities_OrganizationId",
                table: "Availabilities",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Availabilities_Organizations_OrganizationId",
                table: "Availabilities",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Availabilities_Users_UserId",
                table: "Availabilities",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Organizations_OrganizationId",
                table: "Users",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Availabilities_Organizations_OrganizationId",
                table: "Availabilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Availabilities_Users_UserId",
                table: "Availabilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Organizations_OrganizationId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_OrganizationId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Availabilities_OrganizationId",
                table: "Availabilities");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "Availabilities");

            migrationBuilder.RenameColumn(
                name: "OrganizationId",
                table: "Users",
                newName: "UserOrganizationId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Availabilities",
                newName: "UserOrganizationId");

            migrationBuilder.RenameIndex(
                name: "IX_Availabilities_UserId",
                table: "Availabilities",
                newName: "IX_Availabilities_UserOrganizationId");

            migrationBuilder.CreateTable(
                name: "UserOrganizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Role = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOrganizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOrganizations_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOrganizations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserOrganizations_OrganizationId",
                table: "UserOrganizations",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrganizations_UserId",
                table: "UserOrganizations",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Availabilities_UserOrganizations_UserOrganizationId",
                table: "Availabilities",
                column: "UserOrganizationId",
                principalTable: "UserOrganizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
