using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Katabo.Migrations
{
    public partial class optionalshipaddorders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ShippingAddressId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BillingAddressId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 4, 7, 13, 4, 57, 254, DateTimeKind.Local).AddTicks(4479));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 4, 7, 13, 4, 57, 254, DateTimeKind.Local).AddTicks(4483));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 4, 7, 13, 4, 57, 254, DateTimeKind.Local).AddTicks(4487));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 4, 7, 13, 4, 57, 254, DateTimeKind.Local).AddTicks(4492));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2023, 4, 7, 13, 4, 57, 254, DateTimeKind.Local).AddTicks(4496));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Birthday",
                value: new DateTime(2023, 4, 7, 13, 4, 57, 254, DateTimeKind.Local).AddTicks(4665));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Birthday",
                value: new DateTime(2023, 4, 7, 13, 4, 57, 254, DateTimeKind.Local).AddTicks(4672));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ShippingAddressId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BillingAddressId",
                table: "Orders",
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
    }
}
