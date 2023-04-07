using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Katabo.Migrations
{
    public partial class optionaladdressguest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Guests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 4, 7, 12, 34, 19, 29, DateTimeKind.Local).AddTicks(5542));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 4, 7, 12, 34, 19, 29, DateTimeKind.Local).AddTicks(5548));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 4, 7, 12, 34, 19, 29, DateTimeKind.Local).AddTicks(5552));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 4, 7, 12, 34, 19, 29, DateTimeKind.Local).AddTicks(5556));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2023, 4, 7, 12, 34, 19, 29, DateTimeKind.Local).AddTicks(5560));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Birthday",
                value: new DateTime(2023, 4, 7, 12, 34, 19, 29, DateTimeKind.Local).AddTicks(5721));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Birthday",
                value: new DateTime(2023, 4, 7, 12, 34, 19, 29, DateTimeKind.Local).AddTicks(5727));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Guests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
