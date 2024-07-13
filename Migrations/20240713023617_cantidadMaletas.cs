using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvionesBackNet.Migrations
{
    /// <inheritdoc />
    public partial class cantidadMaletas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CantidadMaletasAdquiridas",
                table: "Boletos");

            migrationBuilder.AddColumn<int>(
                name: "CantidadMaletasMax",
                table: "VueloClases",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CantidadMaletasMax",
                table: "VueloClases");

            migrationBuilder.AddColumn<int>(
                name: "CantidadMaletasAdquiridas",
                table: "Boletos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
