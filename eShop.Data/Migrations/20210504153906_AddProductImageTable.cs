using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShop.Data.Migrations
{
    public partial class AddProductImageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 4, 22, 39, 5, 568, DateTimeKind.Local).AddTicks(8852),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 25, 21, 19, 13, 947, DateTimeKind.Local).AddTicks(9448));

            migrationBuilder.CreateTable(
                name: "ProductImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    FileSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImage_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("e9178863-0cd8-49df-8a93-648ddb740db5"),
                column: "ConcurrencyStamp",
                value: "ff093f9c-6fe0-4c27-9e42-6ef1739c7cbf");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0ad41d50-0cf6-4ac0-9523-72a68b12e9a9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9d5b64a2-7b71-4c05-8e14-1f67db5feb2c", "AQAAAAEAACcQAAAAEOc4Dpxhp4ubMXWcvPMKInqhSj6uPAZbFMlLMf2WlhFUJuNzmUYeiefGk9VkbPtOcA==" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_ProductId",
                table: "ProductImage",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImage");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 25, 21, 19, 13, 947, DateTimeKind.Local).AddTicks(9448),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 4, 22, 39, 5, 568, DateTimeKind.Local).AddTicks(8852));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("e9178863-0cd8-49df-8a93-648ddb740db5"),
                column: "ConcurrencyStamp",
                value: "48eacf42-b13e-4cc2-b31b-dcbc0028a8b0");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0ad41d50-0cf6-4ac0-9523-72a68b12e9a9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "675923d0-614c-4adc-b711-52f43e13c1f6", "AQAAAAEAACcQAAAAEG4m+6zWnNeF+AorNihXe971ncbDeySJPk+9fjr5H2h8J2o3N0Mz1ruYldZF4Qg+aA==" });
        }
    }
}
