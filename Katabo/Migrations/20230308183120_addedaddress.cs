using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Katabo.Migrations
{
    public partial class addedaddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Barangay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zipcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "Barangay", "City", "Country", "Province", "Zipcode" },
                values: new object[,]
                {
                    { 1, "Maybacong", "Borongan", "Philippines", "Eastern Samar", "6800" },
                    { 2, "Sabang South", "Borongan", "Philippines", "Eastern Samar", "6800" }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 3, 8, 13, 31, 19, 987, DateTimeKind.Local).AddTicks(5711));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 3, 8, 13, 31, 19, 987, DateTimeKind.Local).AddTicks(5716));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 3, 8, 13, 31, 19, 987, DateTimeKind.Local).AddTicks(5720));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 3, 8, 13, 31, 19, 987, DateTimeKind.Local).AddTicks(5724));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2023, 3, 8, 13, 31, 19, 987, DateTimeKind.Local).AddTicks(5728));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "AddressId", "Birthday" },
                values: new object[] { 2, new DateTime(2023, 3, 8, 13, 31, 19, 987, DateTimeKind.Local).AddTicks(5879) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "AddressId", "Birthday" },
                values: new object[] { 1, new DateTime(2023, 3, 8, 13, 31, 19, 987, DateTimeKind.Local).AddTicks(5884) });

            migrationBuilder.CreateIndex(
                name: "IX_Users_AddressId",
                table: "Users",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Addresses_AddressId",
                table: "Users",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Addresses_AddressId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Users_AddressId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDateTime", "Image" },
                values: new object[] { new DateTime(2023, 3, 6, 23, 46, 12, 429, DateTimeKind.Local).AddTicks(2802), "/images/seafood.png" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "CreatedDateTime", "Image" },
                values: new object[] { new DateTime(2023, 3, 6, 23, 46, 12, 429, DateTimeKind.Local).AddTicks(2808), "/images/meat.png" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                columns: new[] { "CreatedDateTime", "Image" },
                values: new object[] { new DateTime(2023, 3, 6, 23, 46, 12, 429, DateTimeKind.Local).AddTicks(2814), "/images/vegetables.png" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                columns: new[] { "CreatedDateTime", "Image" },
                values: new object[] { new DateTime(2023, 3, 6, 23, 46, 12, 429, DateTimeKind.Local).AddTicks(2819), "/images/fruits.png" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                columns: new[] { "CreatedDateTime", "Image" },
                values: new object[] { new DateTime(2023, 3, 6, 23, 46, 12, 429, DateTimeKind.Local).AddTicks(2824), "/images/root-crops.png" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Address", "Birthday" },
                values: new object[] { "address", new DateTime(2023, 3, 6, 23, 46, 12, 429, DateTimeKind.Local).AddTicks(3196) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "Address", "Birthday" },
                values: new object[] { "address", new DateTime(2023, 3, 6, 23, 46, 12, 429, DateTimeKind.Local).AddTicks(3204) });
        }
    }
}
