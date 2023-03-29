using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Katabo.Migrations
{
    public partial class seededdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CreatedDateTime", "DisplayOrder", "Image", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 6, 23, 46, 12, 429, DateTimeKind.Local).AddTicks(2802), 1, "/images/seafood.png", "Seafoods" },
                    { 2, new DateTime(2023, 3, 6, 23, 46, 12, 429, DateTimeKind.Local).AddTicks(2808), 2, "/images/meat.png", "Meat" },
                    { 3, new DateTime(2023, 3, 6, 23, 46, 12, 429, DateTimeKind.Local).AddTicks(2814), 3, "/images/vegetables.png", "Vegetables" },
                    { 4, new DateTime(2023, 3, 6, 23, 46, 12, 429, DateTimeKind.Local).AddTicks(2819), 4, "/images/fruits.png", "Fruits" },
                    { 5, new DateTime(2023, 3, 6, 23, 46, 12, 429, DateTimeKind.Local).AddTicks(2824), 5, "/images/root-crops.png", "Root Crops" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Image", "Name", "Price", "ProductDescription", "ProductQuantity" },
                values: new object[,]
                {
                    { 1, 1, "/images/bangus.png", "Bangus", 150.0, "description", 100 },
                    { 2, 3, "/images/cabbage.png", "cabbage", 70.0, "description", 100 },
                    { 3, 1, "/images/chicken-drumsticks.png", "Chicken Drumsticks", 200.0, "description", 100 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "Birthday", "Email", "FirstName", "Gender", "LastName", "Password", "PhoneNmber", "Role", "Username" },
                values: new object[,]
                {
                    { 1, "address", new DateTime(2023, 3, 6, 23, 46, 12, 429, DateTimeKind.Local).AddTicks(3196), "admin@admin.com", "admin", "Male", "admin", "password", "09091234567", "Admin", "admin" },
                    { 2, "address", new DateTime(2023, 3, 6, 23, 46, 12, 429, DateTimeKind.Local).AddTicks(3204), "user@user.com", "user", "Female", "user", "password", "09091234567", "User", "user" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

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
