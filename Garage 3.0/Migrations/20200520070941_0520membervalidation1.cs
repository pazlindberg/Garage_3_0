using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage_3._0.Migrations
{
    public partial class _0520membervalidation1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeOfArrival",
                value: new DateTime(2020, 5, 19, 7, 39, 40, 690, DateTimeKind.Local).AddTicks(1337));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeOfArrival",
                value: new DateTime(2020, 5, 19, 7, 39, 40, 694, DateTimeKind.Local).AddTicks(1748));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeOfArrival",
                value: new DateTime(2020, 5, 19, 7, 39, 40, 694, DateTimeKind.Local).AddTicks(1820));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 4,
                column: "TimeOfArrival",
                value: new DateTime(2020, 5, 19, 7, 39, 40, 694, DateTimeKind.Local).AddTicks(1831));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeOfArrival",
                value: new DateTime(2020, 5, 18, 13, 12, 9, 941, DateTimeKind.Local).AddTicks(3761));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeOfArrival",
                value: new DateTime(2020, 5, 18, 13, 12, 9, 944, DateTimeKind.Local).AddTicks(9340));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeOfArrival",
                value: new DateTime(2020, 5, 18, 13, 12, 9, 944, DateTimeKind.Local).AddTicks(9396));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 4,
                column: "TimeOfArrival",
                value: new DateTime(2020, 5, 18, 13, 12, 9, 944, DateTimeKind.Local).AddTicks(9407));
        }
    }
}
