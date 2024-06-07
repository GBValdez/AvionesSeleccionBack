using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvionesBackNet.Migrations
{
    /// <inheritdoc />
    public partial class tripulacionAgregadaAlAvion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TripulacionId",
                table: "Aviones",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Aviones_TripulacionId",
                table: "Aviones",
                column: "TripulacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aviones_Tripulaciones_TripulacionId",
                table: "Aviones",
                column: "TripulacionId",
                principalTable: "Tripulaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aviones_Tripulaciones_TripulacionId",
                table: "Aviones");

            migrationBuilder.DropIndex(
                name: "IX_Aviones_TripulacionId",
                table: "Aviones");

            migrationBuilder.DropColumn(
                name: "TripulacionId",
                table: "Aviones");
        }
    }
}
