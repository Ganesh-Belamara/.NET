using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductApi_Task.Migrations
{
    /// <inheritdoc />
    public partial class usermodified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Products_ProductID",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Users_UserID",
                table: "Carts");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "Products",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 10, 23, 6, 20, 16, 843, DateTimeKind.Utc).AddTicks(4446), true, false });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 10, 23, 6, 20, 16, 843, DateTimeKind.Utc).AddTicks(4461), true, false });

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Products_ProductID",
                table: "Carts",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Users_UserID",
                table: "Carts",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Products_ProductID",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Users_UserID",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "Products",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Products_ProductID",
                table: "Carts",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Users_UserID",
                table: "Carts",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
