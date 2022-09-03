using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HappyTrip.Reservation.System.Repository.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buses",
                columns: table => new
                {
                    BusNumber = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Company = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DriverID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Lid = table.Column<int>(type: "int", nullable: false),
                    BusType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buses", x => x.BusNumber);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    DriverID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LicenseID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.DriverID);
                });

            migrationBuilder.CreateTable(
                name: "StopOvers",
                columns: table => new
                {
                    TripID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sequence = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Period = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StopOvers", x => x.TripID);
                });

            migrationBuilder.CreateTable(
                name: "Terminals",
                columns: table => new
                {
                    TerminalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Area = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terminals", x => x.TerminalID);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    TripID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusNumber = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Origin = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Departure = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Arrival = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.TripID);
                });

            migrationBuilder.InsertData(
                table: "Buses",
                columns: new[] { "BusNumber", "BusType", "Capacity", "Company", "DriverID", "Lid", "Price" },
                values: new object[,]
                {
                    { "FBC001", 0, 40, "Five Star Bus Co.", new Guid("008daf97-f940-436d-9b84-14009f502190"), 40, 100.0 },
                    { "FBC002", 1, 40, "Five Star Bus Co.", new Guid("f1a0b406-fc19-4060-b512-aa19e0b7b3f8"), 40, 150.0 },
                    { "FBC003", 2, 30, "Five Star Bus Co.", new Guid("eb03863f-bd5e-4ad7-9ff7-eb8429780115"), 30, 250.0 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "BirthDate", "FirstName", "LastName", "MiddleName" },
                values: new object[,]
                {
                    { new Guid("0d7fabcb-2fbc-4794-b46e-b8ed3c0e967a"), new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Primrose", "Everdeen", "" },
                    { new Guid("8baf03f1-7911-4156-a650-24e747053557"), new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Katniss", "Everdeen", "" },
                    { new Guid("9c9c20de-5d8e-4ee3-a15d-4bea24e98282"), new DateTime(2000, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Haymitch", "Abernathy", "" },
                    { new Guid("b637f251-9865-4fb6-bea8-6ccc742e9bf5"), new DateTime(2000, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Peeta", "Mellark", "" },
                    { new Guid("ee54793f-e473-4ffa-921e-9559b6192e2a"), new DateTime(2000, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gale", "Hawthorne", "" }
                });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "DriverID", "BirthDate", "FirstName", "LastName", "LicenseID", "MiddleName" },
                values: new object[,]
                {
                    { new Guid("170938bd-8a23-4309-a916-7d462fd02a92"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Caleb", "Prior", "NO1-12-123452", "" },
                    { new Guid("656e6136-e3d4-4710-a29a-42cf1ac4ab45"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Beatrice", "Prior", "NO1-12-123451", "" },
                    { new Guid("78547904-10fe-4dfd-b455-1c337f22b6a4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jeanine", "Matthews", "NO1-12-123453", "" }
                });

            migrationBuilder.InsertData(
                table: "StopOvers",
                columns: new[] { "TripID", "Area", "Period", "Sequence" },
                values: new object[,]
                {
                    { new Guid("222fc3f5-dce8-45d6-8f77-d5365898ff81"), "SLEX", new TimeSpan(0, 0, 15, 0, 0), 1 },
                    { new Guid("4b7ad05b-dded-48fe-9df3-4d1d554ab236"), "SLEX", new TimeSpan(0, 0, 15, 0, 0), 1 }
                });

            migrationBuilder.InsertData(
                table: "Terminals",
                columns: new[] { "TerminalID", "Area", "Company" },
                values: new object[,]
                {
                    { new Guid("26bf7f0f-b351-43c1-8b1d-ce92cd2b8971"), "Five Star Bus Co.", "Pasay, Metro Manila" },
                    { new Guid("d84b40df-15a2-4d27-a75a-1c874dfbeebc"), "Pasay, Metro Manila", "Five Star Bus Co." }
                });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripID", "Arrival", "BusNumber", "Departure", "Destination", "Origin" },
                values: new object[,]
                {
                    { new Guid("222fc3f5-dce8-45d6-8f77-d5365898ff81"), new DateTime(2022, 8, 22, 19, 15, 0, 0, DateTimeKind.Unspecified), "FBC001", new DateTime(2022, 8, 22, 15, 30, 0, 0, DateTimeKind.Unspecified), "Lucena, Quezon", "Pasay, Metro Manila" },
                    { new Guid("3cfb040b-7295-4d8e-b673-c251100e28f5"), new DateTime(2022, 8, 24, 19, 15, 0, 0, DateTimeKind.Unspecified), "FBC003", new DateTime(2022, 8, 24, 15, 30, 0, 0, DateTimeKind.Unspecified), "Lucena, Quezon", "Pasay, Metro Manila" },
                    { new Guid("4b7ad05b-dded-48fe-9df3-4d1d554ab236"), new DateTime(2022, 8, 22, 19, 15, 0, 0, DateTimeKind.Unspecified), "FBC001", new DateTime(2022, 8, 22, 15, 30, 0, 0, DateTimeKind.Unspecified), "Pasay, Metro Manila", "Lucena, Quezon" },
                    { new Guid("5bc1d5d8-6907-470e-a725-ef0a7e863733"), new DateTime(2022, 8, 23, 19, 15, 0, 0, DateTimeKind.Unspecified), "FBC002", new DateTime(2022, 8, 23, 15, 30, 0, 0, DateTimeKind.Unspecified), "Lucena, Quezon", "Pasay, Metro Manila" },
                    { new Guid("99e50980-a5a9-4f43-a3c6-95a7a31a769d"), new DateTime(2022, 8, 23, 19, 15, 0, 0, DateTimeKind.Unspecified), "FBC002", new DateTime(2022, 8, 23, 15, 30, 0, 0, DateTimeKind.Unspecified), "Pasay, Metro Manila", "Lucena, Quezon" },
                    { new Guid("c280b0c3-82a6-408a-8596-b07940cac28a"), new DateTime(2022, 8, 24, 19, 15, 0, 0, DateTimeKind.Unspecified), "FBC003", new DateTime(2022, 8, 24, 15, 30, 0, 0, DateTimeKind.Unspecified), "Pasay, Metro Manila", "Lucena, Quezon" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buses");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "StopOvers");

            migrationBuilder.DropTable(
                name: "Terminals");

            migrationBuilder.DropTable(
                name: "Trips");
        }
    }
}
