using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Katabo.Migrations
{
    public partial class guest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 4, 2, 20, 53, 36, 413, DateTimeKind.Local).AddTicks(8584));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 4, 2, 20, 53, 36, 413, DateTimeKind.Local).AddTicks(8592));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 4, 2, 20, 53, 36, 413, DateTimeKind.Local).AddTicks(8600));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 4, 2, 20, 53, 36, 413, DateTimeKind.Local).AddTicks(8606));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2023, 4, 2, 20, 53, 36, 413, DateTimeKind.Local).AddTicks(8612));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Birthday",
                value: new DateTime(2023, 4, 2, 20, 53, 36, 413, DateTimeKind.Local).AddTicks(8999));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Birthday",
                value: new DateTime(2023, 4, 2, 20, 53, 36, 413, DateTimeKind.Local).AddTicks(9012));
        }
    }
}
