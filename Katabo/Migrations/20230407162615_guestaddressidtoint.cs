using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Katabo.Migrations
{
    public partial class guestaddressidtoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Guests",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 4, 7, 12, 26, 14, 487, DateTimeKind.Local).AddTicks(7381));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 4, 7, 12, 26, 14, 487, DateTimeKind.Local).AddTicks(7385));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 4, 7, 12, 26, 14, 487, DateTimeKind.Local).AddTicks(7390));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 4, 7, 12, 26, 14, 487, DateTimeKind.Local).AddTicks(7393));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2023, 4, 7, 12, 26, 14, 487, DateTimeKind.Local).AddTicks(7398));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Birthday",
                value: new DateTime(2023, 4, 7, 12, 26, 14, 487, DateTimeKind.Local).AddTicks(7545));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Birthday",
                value: new DateTime(2023, 4, 7, 12, 26, 14, 487, DateTimeKind.Local).AddTicks(7551));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AddressId",
                table: "Guests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
