using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cradle.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CradleContextSecond : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AspNetRoles",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SchoolId",
                table: "AspNetRoles",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AspNetRoleClaims",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Group",
                table: "AspNetRoleClaims",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SchoolId",
                table: "AspNetRoleClaims",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "SchoolId",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AspNetRoleClaims");

            migrationBuilder.DropColumn(
                name: "Group",
                table: "AspNetRoleClaims");

            migrationBuilder.DropColumn(
                name: "SchoolId",
                table: "AspNetRoleClaims");
        }
    }
}
