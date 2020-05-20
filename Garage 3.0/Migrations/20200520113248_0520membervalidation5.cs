using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage_3._0.Migrations
{
    public partial class _0520membervalidation5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeOfArrival",
                value: new DateTime(2020, 5, 19, 12, 2, 48, 169, DateTimeKind.Local).AddTicks(9967));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeOfArrival",
                value: new DateTime(2020, 5, 19, 12, 2, 48, 173, DateTimeKind.Local).AddTicks(9018));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeOfArrival",
                value: new DateTime(2020, 5, 19, 12, 2, 48, 173, DateTimeKind.Local).AddTicks(9082));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 4,
                column: "TimeOfArrival",
                value: new DateTime(2020, 5, 19, 12, 2, 48, 173, DateTimeKind.Local).AddTicks(9093));

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_MemberId",
                table: "Vehicle",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_VehicleTypeId",
                table: "Vehicle",
                column: "VehicleTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Member_MemberId",
                table: "Vehicle",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_VehicleType_VehicleTypeId",
                table: "Vehicle",
                column: "VehicleTypeId",
                principalTable: "VehicleType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Member_MemberId",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_VehicleType_VehicleTypeId",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_MemberId",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_VehicleTypeId",
                table: "Vehicle");

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
