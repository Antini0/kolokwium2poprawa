using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kolokwium2poprawa.Migrations
{
    /// <inheritdoc />
    public partial class Init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    IdCar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VIN = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Seats = table.Column<int>(type: "int", nullable: false),
                    PricePerDay = table.Column<int>(type: "int", nullable: false),
                    IdModel = table.Column<int>(type: "int", nullable: false),
                    IdColor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.IdCar);
                    table.ForeignKey(
                        name: "FK_Cars_Colors_IdColor",
                        column: x => x.IdColor,
                        principalTable: "Colors",
                        principalColumn: "IdColor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Models_IdModel",
                        column: x => x.IdModel,
                        principalTable: "Models",
                        principalColumn: "IdModel",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_IdColor",
                table: "Cars",
                column: "IdColor");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_IdModel",
                table: "Cars",
                column: "IdModel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
