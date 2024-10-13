using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TastyTreats.Migrations
{
    /// <inheritdoc />
    public partial class UpdateApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Users_UserId1",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId1",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Carts_UserId1",
                table: "Carts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "CartItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "CartItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "c0ecfb33-a55b-41c3-ab98-7e10cfabf31b");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "e4b17116-a4cc-49fe-acdd-913adeba011a");

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "CartId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "CartId",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Carts");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.AddColumn<int>(
                name: "UserId2",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RoleId1",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserPicture",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "UserId");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "48f1fab6-1d4b-426a-aaeb-e9cb7008ad07", null, "user", "USER" },
                    { "d4050831-c7d8-48d4-b239-64ea11e1cfe2", null, "admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId2",
                table: "Carts",
                column: "UserId2",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RoleId1",
                table: "AspNetUsers",
                column: "RoleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Role_RoleId1",
                table: "AspNetUsers",
                column: "RoleId1",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_User_UserId2",
                table: "Carts",
                column: "UserId2",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_User_UserId1",
                table: "Orders",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Role_RoleId1",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_User_UserId2",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_User_UserId1",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Carts_UserId2",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RoleId1",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "48f1fab6-1d4b-426a-aaeb-e9cb7008ad07");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "d4050831-c7d8-48d4-b239-64ea11e1cfe2");

            migrationBuilder.DropColumn(
                name: "UserId2",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RoleId1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserPicture",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Carts",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "CartId", "UserId", "UserId1" },
                values: new object[,]
                {
                    { 1, 1, null },
                    { 2, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c0ecfb33-a55b-41c3-ab98-7e10cfabf31b", null, "admin", "ADMIN" },
                    { "e4b17116-a4cc-49fe-acdd-913adeba011a", null, "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "CartItemId", "CartId", "ItemId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 2 },
                    { 2, 2, 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId1",
                table: "Carts",
                column: "UserId1",
                unique: true,
                filter: "[UserId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Users_UserId1",
                table: "Carts",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId1",
                table: "Orders",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
