using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvionesBackNet.Migrations
{
    /// <inheritdoc />
    public partial class codigoAvion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Tripulaciones_TripulacionId",
                table: "Empleados");

            migrationBuilder.AlterColumn<long>(
                name: "TripulacionId",
                table: "Empleados",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "Aviones",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Tripulaciones_TripulacionId",
                table: "Empleados",
                column: "TripulacionId",
                principalTable: "Tripulaciones",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Tripulaciones_TripulacionId",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Aviones");

            migrationBuilder.AlterColumn<long>(
                name: "TripulacionId",
                table: "Empleados",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Tripulaciones_TripulacionId",
                table: "Empleados",
                column: "TripulacionId",
                principalTable: "Tripulaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
