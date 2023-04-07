using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Katabo.Migrations
{
    public partial class guesttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    GuestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.GuestId);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 4, 7, 9, 33, 0, 278, DateTimeKind.Local).AddTicks(8152));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 4, 7, 9, 33, 0, 278, DateTimeKind.Local).AddTicks(8158));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 4, 7, 9, 33, 0, 278, DateTimeKind.Local).AddTicks(8162));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 4, 7, 9, 33, 0, 278, DateTimeKind.Local).AddTicks(8166));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2023, 4, 7, 9, 33, 0, 278, DateTimeKind.Local).AddTicks(8171));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Birthday",
                value: new DateTime(2023, 4, 7, 9, 33, 0, 278, DateTimeKind.Local).AddTicks(8431));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Birthday",
                value: new DateTime(2023, 4, 7, 9, 33, 0, 278, DateTimeKind.Local).AddTicks(8439));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 4, 7, 9, 28, 47, 236, DateTimeKind.Local).AddTicks(5473));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 4, 7, 9, 28, 47, 236, DateTimeKind.Local).AddTicks(5480));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 4, 7, 9, 28, 47, 236, DateTimeKind.Local).AddTicks(5487));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 4, 7, 9, 28, 47, 236, DateTimeKind.Local).AddTicks(5493));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2023, 4, 7, 9, 28, 47, 236, DateTimeKind.Local).AddTicks(5499));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Birthday",
                value: new DateTime(2023, 4, 7, 9, 28, 47, 236, DateTimeKind.Local).AddTicks(5791));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Birthday",
                value: new DateTime(2023, 4, 7, 9, 28, 47, 236, DateTimeKind.Local).AddTicks(5802));
        }
    }
}
