using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace kolokwium2poprawa.Migrations
{
    /// <inheritdoc />
    public partial class Init6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "IdClient", "Adress", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "zzz", "Jan", "Kowalski" },
                    { 2, "fff", "cc", "pp" }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "IdColor", "Name" },
                values: new object[,]
                {
                    { 1, "zielony" },
                    { 2, "czerwony" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "IdModel", "Name" },
                values: new object[,]
                {
                    { 1, "kombi" },
                    { 2, "cos" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "IdCar", "IdColor", "IdModel", "Name", "PricePerDay", "Seats", "VIN" },
                values: new object[,]
                {
                    { 1, 1, 1, "dacia", 100, 4, "gggg" },
                    { 2, 1, 2, "porche", 300, 6, "vvvv" }
                });

            migrationBuilder.InsertData(
                table: "CarRentals",
                columns: new[] { "IdCar_Rental", "DateFrom", "DateTo", "Disscount", "IdCar", "IdClient", "TotalPrice" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 1, 1, 1000 },
                    { 2, new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 2, 2, 500 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CarRentals",
                keyColumn: "IdCar_Rental",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CarRentals",
                keyColumn: "IdCar_Rental",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "IdColor",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "IdClient",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "IdClient",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "IdColor",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "IdModel",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "IdModel",
                keyValue: 2);
        }
    }
}
