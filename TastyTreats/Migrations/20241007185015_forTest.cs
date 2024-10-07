using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TastyTreats.Migrations
{
    /// <inheritdoc />
    public partial class forTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ItemPicture",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "AddRoleViewModel",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 7, 21, 50, 13, 520, DateTimeKind.Local).AddTicks(6311));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 7, 21, 50, 13, 520, DateTimeKind.Local).AddTicks(6319));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 7, 21, 50, 13, 520, DateTimeKind.Local).AddTicks(6211));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 7, 21, 50, 13, 520, DateTimeKind.Local).AddTicks(6279));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddRoleViewModel");

            migrationBuilder.AlterColumn<string>(
                name: "ItemPicture",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 3, 22, 17, 49, 983, DateTimeKind.Local).AddTicks(5504));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 3, 22, 17, 49, 983, DateTimeKind.Local).AddTicks(5514));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 3, 22, 17, 49, 983, DateTimeKind.Local).AddTicks(5390));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 3, 22, 17, 49, 983, DateTimeKind.Local).AddTicks(5457));
        }
    }
}
