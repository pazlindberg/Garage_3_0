using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage_3._0.Migrations
{
    public partial class _0520membervalidation4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeOfArrival",
                value: new DateTime(2020, 5, 19, 8, 26, 30, 611, DateTimeKind.Local).AddTicks(6306));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeOfArrival",
                value: new DateTime(2020, 5, 19, 8, 26, 30, 615, DateTimeKind.Local).AddTicks(2713));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeOfArrival",
                value: new DateTime(2020, 5, 19, 8, 26, 30, 615, DateTimeKind.Local).AddTicks(2771));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 4,
                column: "TimeOfArrival",
                value: new DateTime(2020, 5, 19, 8, 26, 30, 615, DateTimeKind.Local).AddTicks(2781));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeOfArrival",
                value: new DateTime(2020, 5, 19, 7, 43, 56, 885, DateTimeKind.Local).AddTicks(1973));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeOfArrival",
                value: new DateTime(2020, 5, 19, 7, 43, 56, 889, DateTimeKind.Local).AddTicks(669));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeOfArrival",
                value: new DateTime(2020, 5, 19, 7, 43, 56, 889, DateTimeKind.Local).AddTicks(733));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 4,
                column: "TimeOfArrival",
                value: new DateTime(2020, 5, 19, 7, 43, 56, 889, DateTimeKind.Local).AddTicks(744));
        }
    }
}
