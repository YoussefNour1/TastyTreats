using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TastyTreats.Migrations
{
    /// <inheritdoc />
    public partial class SeedAllData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Various types of drinks.", "Beverages" },
                    { 2, "Tasty snacks and munchies.", "Snacks" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "City", "Country", "Email", "Name", "Password", "Phone", "Role", "UserPicture", "ZipCode" },
                values: new object[,]
                {
                    { 1, "New York", "USA", "john.doe@example.com", "John Doe", "Password@123", 1234567890, "User", "john_picture.png", "12345" },
                    { 2, "London", "UK", "jane.smith@example.com", "Jane Smith", "11111111", 1098765432, "Admin", "jane_picture.jpg", "54321" },
                    { 3, "Toronto", "Canada", "sam.wilson@example.com", "Sam Wilson", "SamWilson@99", 1987654321, "User", "sam_picture.jpg", "67890" }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "CartId", "Quantity", "UserId" },
                values: new object[,]
                {
                    { 1, 2, 1 },
                    { 2, 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "Availability", "CategoryId", "Description", "Discount", "ItemPicture", "Name", "Price" },
                values: new object[,]
                {
                    { 1, true, 1, "Refreshing cola drink.", 0.50m, "coke.png", "Coke", 1.99m },
                    { 2, true, 2, "Crunchy potato chips.", null, "chips.png", "Chips", 2.49m }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CreatedAt", "OrderStatus", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 16, 10, 3, 33, 348, DateTimeKind.Local).AddTicks(9570), "Completed", 5.97m, null, 1 },
                    { 2, new DateTime(2024, 9, 16, 10, 3, 33, 348, DateTimeKind.Local).AddTicks(9620), "Pending", 2.49m, null, 2 }
                });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "CartItemId", "CartId", "ItemId", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 1.99m, 2 },
                    { 2, 2, 2, 2.49m, 1 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "OrderItemId", "CreatedAt", "ItemId", "OrderId", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 16, 10, 3, 33, 348, DateTimeKind.Local).AddTicks(9648), 1, 1, 1.99m, 2 },
                    { 2, new DateTime(2024, 9, 16, 10, 3, 33, 348, DateTimeKind.Local).AddTicks(9654), 2, 2, 2.49m, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "CartItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "CartItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "CartId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "CartId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);
        }
    }
}
