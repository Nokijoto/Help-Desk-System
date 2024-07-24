using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceDesk.Assets.Storage.Migrations
{
    /// <inheritdoc />
    public partial class addCables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CableType",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConnectorType",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsShielded",
                table: "Assets",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Length",
                table: "Assets",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CableType",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "ConnectorType",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "IsShielded",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "Assets");
        }
    }
}
