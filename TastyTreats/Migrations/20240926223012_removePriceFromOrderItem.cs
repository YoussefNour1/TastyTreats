using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TastyTreats.Migrations
{
    /// <inheritdoc />
    public partial class removePriceFromOrderItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "CartItems");

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 27, 1, 30, 10, 877, DateTimeKind.Local).AddTicks(5777));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 27, 1, 30, 10, 877, DateTimeKind.Local).AddTicks(5786));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 27, 1, 30, 10, 877, DateTimeKind.Local).AddTicks(5659));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 27, 1, 30, 10, 877, DateTimeKind.Local).AddTicks(5732));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "OrderItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "CartItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "CartItemId",
                keyValue: 1,
                column: "Price",
                value: 1.99m);

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "CartItemId",
                keyValue: 2,
                column: "Price",
                value: 2.49m);

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "CartId",
                keyValue: 1,
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "CartId",
                keyValue: 2,
                column: "Quantity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Price" },
                values: new object[] { new DateTime(2024, 9, 16, 10, 3, 33, 348, DateTimeKind.Local).AddTicks(9648), 1.99m });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Price" },
                values: new object[] { new DateTime(2024, 9, 16, 10, 3, 33, 348, DateTimeKind.Local).AddTicks(9654), 2.49m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 16, 10, 3, 33, 348, DateTimeKind.Local).AddTicks(9570));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 16, 10, 3, 33, 348, DateTimeKind.Local).AddTicks(9620));
        }
    }
}
