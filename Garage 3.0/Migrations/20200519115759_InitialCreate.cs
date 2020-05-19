using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage_3._0.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegNr = table.Column<string>(maxLength: 32, nullable: false),
                    ParkingSpaceId = table.Column<int>(nullable: true),
                    VehicleTypeId = table.Column<int>(nullable: false),
                    MemberId = table.Column<int>(nullable: false),
                    NrOfWheels = table.Column<int>(nullable: false),
                    Color = table.Column<string>(maxLength: 32, nullable: true),
                    Brand = table.Column<string>(maxLength: 32, nullable: true),
                    Model = table.Column<string>(maxLength: 64, nullable: true),
                    TimeOfArrival = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(nullable: true),
                    Size = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleType", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Member",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "johan.andersson@gmail.com", "Johan", "Andersson" },
                    { 2, "anna.lind@yahoo.se", "Anna", "Lind" },
                    { 3, "dimman@lexicon.se", "Dimitris", "Björlingh" },
                    { 4, "bruce.lee@jeetkunedo.cn", "Bruce", "Lee" },
                    { 5, "saka.kivi@soumi.fi", "Sakari", "Kivimäki" }
                });

            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "Id", "Brand", "Color", "MemberId", "Model", "NrOfWheels", "ParkingSpaceId", "RegNr", "TimeOfArrival", "VehicleTypeId" },
                values: new object[,]
                {
                    { 1, "aaa", "White", 1, "model1", 4, null, "US_LM126", new DateTime(2020, 5, 18, 12, 27, 59, 393, DateTimeKind.Local).AddTicks(7262), 1 },
                    { 2, "bbb", "Black", 2, "model2", 1, null, "BVG17", new DateTime(2020, 5, 18, 12, 27, 59, 395, DateTimeKind.Local).AddTicks(9815), 2 },
                    { 3, "ccc", "Blue", 3, "model3", 6, null, "BUS123", new DateTime(2020, 5, 18, 12, 27, 59, 395, DateTimeKind.Local).AddTicks(9858), 3 },
                    { 4, "ddd", "Red", 4, "model4", 4, null, "ABC123", new DateTime(2020, 5, 18, 12, 27, 59, 395, DateTimeKind.Local).AddTicks(9864), 4 }
                });

            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "Id", "Brand", "Color", "MemberId", "Model", "NrOfWheels", "ParkingSpaceId", "RegNr", "VehicleTypeId" },
                values: new object[] { 5, "eee", "Yellow", 1, "model5", 2, null, "ADZ967", 2 });

            migrationBuilder.InsertData(
                table: "VehicleType",
                columns: new[] { "Id", "Size", "TypeName" },
                values: new object[,]
                {
                    { 1, 2.0, "Airplane" },
                    { 2, 2.0, "Car" },
                    { 3, 2.0, "Motorcycle" },
                    { 4, 2.0, "Bus" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Member_Email",
                table: "Member",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_RegNr",
                table: "Vehicle",
                column: "RegNr",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "VehicleType");
        }
    }
}
