using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvionesBackNet.Migrations
{
    /// <inheritdoc />
    public partial class claseEnBoleto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ClaseId",
                table: "Boletos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Boletos_ClaseId",
                table: "Boletos",
                column: "ClaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Boletos_Catalogos_ClaseId",
                table: "Boletos",
                column: "ClaseId",
                principalTable: "Catalogos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boletos_Catalogos_ClaseId",
                table: "Boletos");

            migrationBuilder.DropIndex(
                name: "IX_Boletos_ClaseId",
                table: "Boletos");

            migrationBuilder.DropColumn(
                name: "ClaseId",
                table: "Boletos");
        }
    }
}
