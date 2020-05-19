using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage_3._0.Migrations
{
    public partial class _0519init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeOfArrival",
                value: new DateTime(2020, 5, 18, 12, 44, 50, 951, DateTimeKind.Local).AddTicks(9619));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeOfArrival",
                value: new DateTime(2020, 5, 18, 12, 44, 50, 955, DateTimeKind.Local).AddTicks(7650));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeOfArrival",
                value: new DateTime(2020, 5, 18, 12, 44, 50, 955, DateTimeKind.Local).AddTicks(7713));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 4,
                column: "TimeOfArrival",
                value: new DateTime(2020, 5, 18, 12, 44, 50, 955, DateTimeKind.Local).AddTicks(7723));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeOfArrival",
                value: new DateTime(2020, 5, 18, 12, 27, 59, 393, DateTimeKind.Local).AddTicks(7262));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeOfArrival",
                value: new DateTime(2020, 5, 18, 12, 27, 59, 395, DateTimeKind.Local).AddTicks(9815));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeOfArrival",
                value: new DateTime(2020, 5, 18, 12, 27, 59, 395, DateTimeKind.Local).AddTicks(9858));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 4,
                column: "TimeOfArrival",
                value: new DateTime(2020, 5, 18, 12, 27, 59, 395, DateTimeKind.Local).AddTicks(9864));
        }
    }
}
