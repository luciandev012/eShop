using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShop.Data.Migrations
{
    public partial class seedIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeoAlias",
                table: "Products");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 25, 21, 19, 13, 947, DateTimeKind.Local).AddTicks(9448),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 25, 19, 3, 36, 525, DateTimeKind.Local).AddTicks(771));

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("e9178863-0cd8-49df-8a93-648ddb740db5"), "48eacf42-b13e-4cc2-b31b-dcbc0028a8b0", "Administrator role", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("e9178863-0cd8-49df-8a93-648ddb740db5"), new Guid("0ad41d50-0cf6-4ac0-9523-72a68b12e9a9") });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("0ad41d50-0cf6-4ac0-9523-72a68b12e9a9"), 0, "675923d0-614c-4adc-b711-52f43e13c1f6", new DateTime(1998, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "thanguk04@gmail.com", true, "Thang", "Duong", false, null, "thanguk04@gmail.com", "admin", "AQAAAAEAACcQAAAAEG4m+6zWnNeF+AorNihXe971ncbDeySJPk+9fjr5H2h8J2o3N0Mz1ruYldZF4Qg+aA==", null, false, "", false, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("e9178863-0cd8-49df-8a93-648ddb740db5"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e9178863-0cd8-49df-8a93-648ddb740db5"), new Guid("0ad41d50-0cf6-4ac0-9523-72a68b12e9a9") });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0ad41d50-0cf6-4ac0-9523-72a68b12e9a9"));

            migrationBuilder.AddColumn<string>(
                name: "SeoAlias",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 25, 19, 3, 36, 525, DateTimeKind.Local).AddTicks(771),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 25, 21, 19, 13, 947, DateTimeKind.Local).AddTicks(9448));
        }
    }
}
