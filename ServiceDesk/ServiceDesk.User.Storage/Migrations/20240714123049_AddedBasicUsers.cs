using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ServiceDesk.User.Storage.Migrations
{
    /// <inheritdoc />
    public partial class AddedBasicUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("73f2d809-47e7-438a-a184-0140e36a479d"), null, "Customer", "CUSTOMER" },
                    { new Guid("aa85deb5-cba8-4117-8741-e57edcacd503"), null, "ServiceMan", "SERVICEMAN" },
                    { new Guid("c516e8b7-4657-4b1c-a003-b1c9bfa4c768"), null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsActive", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("03e9693a-c88a-4b6c-9f74-b59f45285cd4"), 0, "c86aa3ee-d677-4980-9928-2f62d6b911fe", "customer@example.com", true, true, false, null, "Customer", "CUSTOMER@EXAMPLE.COM", "CUSTOMER@EXAMPLE.COM", "AQAAAAIAAYagAAAAEIXKcTNOtduI96VY/kQ9d8kExFO9VEp96F4U2qfOLYUZRCxnsDeHaNUGHu4LICqA0g==", null, false, "", false, "customer@example.com" },
                    { new Guid("7ebd3a9a-0b5e-40b8-8386-778127bc2326"), 0, "f383e101-214b-46e2-bdf6-f28e2b488ffd", "admin@example.com", true, true, false, null, "Administrator", "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEFP22nnwLt41CAQHlrybiQMJADdlQuPne8LS/lFm/2XZtTNeCj7RG7alWSb9joiNLg==", null, false, "", false, "admin@example.com" },
                    { new Guid("d99ba96c-4f14-4cee-88bb-4075b1f27908"), 0, "ff716bae-c282-4ffe-a66c-bd5558c66339", "serviceman@example.com", true, true, false, null, "ServiceMan", "SERVICEMAN@EXAMPLE.COM", "SERVICEMAN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEFQouvMYnaqcnyio9FcKMisTju6HSpLk9y05eIw8Vl5hiYl+2QNQOfxKXL+Q/1rBwQ==", null, false, "", false, "serviceman@example.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("73f2d809-47e7-438a-a184-0140e36a479d"), new Guid("03e9693a-c88a-4b6c-9f74-b59f45285cd4") },
                    { new Guid("c516e8b7-4657-4b1c-a003-b1c9bfa4c768"), new Guid("7ebd3a9a-0b5e-40b8-8386-778127bc2326") },
                    { new Guid("aa85deb5-cba8-4117-8741-e57edcacd503"), new Guid("d99ba96c-4f14-4cee-88bb-4075b1f27908") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("73f2d809-47e7-438a-a184-0140e36a479d"), new Guid("03e9693a-c88a-4b6c-9f74-b59f45285cd4") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c516e8b7-4657-4b1c-a003-b1c9bfa4c768"), new Guid("7ebd3a9a-0b5e-40b8-8386-778127bc2326") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("aa85deb5-cba8-4117-8741-e57edcacd503"), new Guid("d99ba96c-4f14-4cee-88bb-4075b1f27908") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("73f2d809-47e7-438a-a184-0140e36a479d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("aa85deb5-cba8-4117-8741-e57edcacd503"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c516e8b7-4657-4b1c-a003-b1c9bfa4c768"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("03e9693a-c88a-4b6c-9f74-b59f45285cd4"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7ebd3a9a-0b5e-40b8-8386-778127bc2326"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d99ba96c-4f14-4cee-88bb-4075b1f27908"));
        }
    }
}
