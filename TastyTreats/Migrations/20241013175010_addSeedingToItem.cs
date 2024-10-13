using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TastyTreats.Migrations
{
    /// <inheritdoc />
    public partial class addSeedingToItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { 3, "Various types of Deserts.", "Deserts" },
                    { 4, "Soup is a liquid-based dish, often savory.", "Soup" },
                    { 5, "A staple food made from dough, typically baked.", "Bread" },
                    { 6, "A dish made primarily from raw or cooked vegetables.", "Salad" },
                    { 7, "A versatile dish consisting of bread with fillings.", "Sandwich" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "Availability", "CategoryId", "Description", "Discount", "ItemPicture", "Name", "Price" },
                values: new object[,]
                {
                    { 3, false, 2, "Lorem, deren, trataro, filede, nerada.", 0.30m, "/img/mozzarella_d1a8f62f-31ca-4c48-936f-1077b8a6c6fe.jpg", "Mozzarella Stick", 8.00m },
                    { 4, true, 1, "A delicate crab cake served on a toasted roll with lettuce and tartar sauce.", 0.30m, "/img/cake_c69bec60-aca2-472c-8a9c-e4365167d909.jpg", "Cake", 9.00m },
                    { 5, true, 2, "Grilled chicken with provolone, artichoke hearts, and roasted red pesto.", 0.10m, "/img/tuscan-grilled_92567c02-132a-40c8-a31d-4d0a9a6012ed.jpg", "Tuscan Grilled", 7.50m },
                    { 6, true, 4, "A rich and creamy soup made from lobster shells, butter, cream, and aromatic herbs.", 0.50m, "/img/-bisque_944a569a-f338-43bc-bce4-bd87930ba6b3.jpg", "Lobster Bisque", 5.95m },
                    { 7, true, 5, "A rustic, round loaf of bread baked in a cylindrical shape.", 0.00m, "/img/bread-barrel_f59cfba4-d6e0-45dd-8121-660ee0494f3a.jpg", "Bread Barrel", 6.59m },
                    { 8, false, 6, "Crisp romaine lettuce, Caesar dressing, croutons, Parmesan cheese, and toppings.", 0.10m, "/img/caesar_cbd4d8eb-7b09-4919-96b5-b383f55b365a.jpg", "Caesar Selections", 8.95m },
                    { 9, true, 6, "Fresh spinach, romaine, tomatoes, and Greek olives.", 0.00m, "/img/greek-salad_9468cfd8-7d81-4c25-a098-7421f5db66d5.jpg", "Greek Salad", 9.95m },
                    { 10, true, 6, "Fresh spinach with mushrooms, hard-boiled egg, and warm bacon vinaigrette.", 0.25m, "/img/spinach-salad_fb2d649d-77ea-4307-b009-a81801f99c3e.jpg", "Spinach Salad", 9.95m },
                    { 11, true, 7, "Plump lobster meat, mayo, and crisp lettuce on a toasted bulky roll.", 0.30m, "/img/lobster-roll_f903779d-4a00-4e5a-9243-51776bc47f23.jpg", "Lobster Roll", 12.95m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 7);
        }
    }
}
