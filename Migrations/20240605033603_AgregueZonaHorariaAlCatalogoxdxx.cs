using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvionesBackNet.Migrations
{
    /// <inheritdoc />
    public partial class AgregueZonaHorariaAlCatalogoxdxx : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BitacoraEncabezados_AspNetUsers_UserId1",
                table: "BitacoraEncabezados");

            migrationBuilder.DropIndex(
                name: "IX_BitacoraEncabezados_UserId1",
                table: "BitacoraEncabezados");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "BitacoraEncabezados");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "BitacoraEncabezados",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_BitacoraEncabezados_UserId",
                table: "BitacoraEncabezados",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BitacoraEncabezados_AspNetUsers_UserId",
                table: "BitacoraEncabezados",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BitacoraEncabezados_AspNetUsers_UserId",
                table: "BitacoraEncabezados");

            migrationBuilder.DropIndex(
                name: "IX_BitacoraEncabezados_UserId",
                table: "BitacoraEncabezados");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "BitacoraEncabezados",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "BitacoraEncabezados",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_BitacoraEncabezados_UserId1",
                table: "BitacoraEncabezados",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BitacoraEncabezados_AspNetUsers_UserId1",
                table: "BitacoraEncabezados",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
