using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kolokwium2poprawa.Migrations
{
    /// <inheritdoc />
    public partial class Init5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarRentals",
                columns: table => new
                {
                    IdCar_Rental = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    IdCar = table.Column<int>(type: "int", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<int>(type: "int", nullable: false),
                    Disscount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarRentals", x => x.IdCar_Rental);
                    table.ForeignKey(
                        name: "FK_CarRentals_Cars_IdCar",
                        column: x => x.IdCar,
                        principalTable: "Cars",
                        principalColumn: "IdCar",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarRentals_Clients_IdClient",
                        column: x => x.IdClient,
                        principalTable: "Clients",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarRentals_IdCar",
                table: "CarRentals",
                column: "IdCar");

            migrationBuilder.CreateIndex(
                name: "IX_CarRentals_IdClient",
                table: "CarRentals",
                column: "IdClient");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarRentals");
        }
    }
}
