using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceDesk.Assets.Storage.Migrations
{
    /// <inheritdoc />
    public partial class otherentities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ActivationDate",
                table: "Assets",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Carrier",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConnectionType",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Connectivity",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceType",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiryDate",
                table: "Assets",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasScanner",
                table: "Assets",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IMEI",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsColor",
                table: "Assets",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCurved",
                table: "Assets",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsManaged",
                table: "Assets",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPortable",
                table: "Assets",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSmartphone",
                table: "Assets",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsVentilated",
                table: "Assets",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LicenseExpiryDate",
                table: "Assets",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LicenseKey",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxPowerOutput",
                table: "Assets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxWeight",
                table: "Assets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfPorts",
                table: "Assets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfUnits",
                table: "Assets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfUsers",
                table: "Assets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PanelType",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaperCapacity",
                table: "Assets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone_OperatingSystem",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Phone_StorageSize",
                table: "Assets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlanType",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PowerCapacity",
                table: "Assets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrintSpeed",
                table: "Assets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrinterType",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RefreshRate",
                table: "Assets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Resolution",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ScreenSize",
                table: "Assets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Simcard_Carrier",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Simcard_PhoneNumber",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Vendor",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Version",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivationDate",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "Carrier",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "ConnectionType",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "Connectivity",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "DeviceType",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "ExpiryDate",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "HasScanner",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "IMEI",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "IsColor",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "IsCurved",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "IsManaged",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "IsPortable",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "IsSmartphone",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "IsVentilated",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "LicenseExpiryDate",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "LicenseKey",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "MaxPowerOutput",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "MaxWeight",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "NumberOfPorts",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "NumberOfUnits",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "NumberOfUsers",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "PanelType",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "PaperCapacity",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "Phone_OperatingSystem",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "Phone_StorageSize",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "PlanType",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "PowerCapacity",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "PrintSpeed",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "PrinterType",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "RefreshRate",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "Resolution",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "ScreenSize",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "Simcard_Carrier",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "Simcard_PhoneNumber",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "Vendor",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Assets");
        }
    }
}
