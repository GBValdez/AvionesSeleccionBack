using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvionesBackNet.Migrations
{
    /// <inheritdoc />
    public partial class tripulationAvionId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<long>(
                name: "AvionId",
                table: "Tripulaciones",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tripulaciones_AvionId",
                table: "Tripulaciones",
                column: "AvionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tripulaciones_Aviones_AvionId",
                table: "Tripulaciones",
                column: "AvionId",
                principalTable: "Aviones",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tripulaciones_Aviones_AvionId",
                table: "Tripulaciones");

            migrationBuilder.DropIndex(
                name: "IX_Tripulaciones_AvionId",
                table: "Tripulaciones");

            migrationBuilder.DropColumn(
                name: "AvionId",
                table: "Tripulaciones");

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
    }
}
