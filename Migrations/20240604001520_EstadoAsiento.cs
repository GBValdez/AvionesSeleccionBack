using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvionesBackNet.Migrations
{
    /// <inheritdoc />
    public partial class EstadoAsiento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "EstadoId",
                table: "Asientos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Asientos_EstadoId",
                table: "Asientos",
                column: "EstadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Asientos_Catalogos_EstadoId",
                table: "Asientos",
                column: "EstadoId",
                principalTable: "Catalogos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asientos_Catalogos_EstadoId",
                table: "Asientos");

            migrationBuilder.DropIndex(
                name: "IX_Asientos_EstadoId",
                table: "Asientos");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "Asientos");
        }
    }
}
