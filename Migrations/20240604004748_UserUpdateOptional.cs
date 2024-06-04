using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvionesBackNet.Migrations
{
    /// <inheritdoc />
    public partial class UserUpdateOptional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AerolineaAeropuertos_AspNetUsers_userUpdateId",
                table: "AerolineaAeropuertos");

            migrationBuilder.DropForeignKey(
                name: "FK_Aerolineas_AspNetUsers_userUpdateId",
                table: "Aerolineas");

            migrationBuilder.DropForeignKey(
                name: "FK_Aeropuertos_AspNetUsers_userUpdateId",
                table: "Aeropuertos");

            migrationBuilder.DropForeignKey(
                name: "FK_Asientos_AspNetUsers_userUpdateId",
                table: "Asientos");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_userUpdateId",
                table: "AspNetRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Aviones_AspNetUsers_userUpdateId",
                table: "Aviones");

            migrationBuilder.DropForeignKey(
                name: "FK_BitacoraCuerpos_AspNetUsers_userUpdateId",
                table: "BitacoraCuerpos");

            migrationBuilder.DropForeignKey(
                name: "FK_BitacoraEncabezados_AspNetUsers_userUpdateId",
                table: "BitacoraEncabezados");

            migrationBuilder.DropForeignKey(
                name: "FK_Boletos_AspNetUsers_userUpdateId",
                table: "Boletos");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalogos_AspNetUsers_userUpdateId",
                table: "Catalogos");

            migrationBuilder.DropForeignKey(
                name: "FK_CatalogoTipos_AspNetUsers_userUpdateId",
                table: "CatalogoTipos");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_AspNetUsers_userUpdateId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_AspNetUsers_userUpdateId",
                table: "Empleados");

            migrationBuilder.DropForeignKey(
                name: "FK_ModeloAvionAerolineas_AspNetUsers_userUpdateId",
                table: "ModeloAvionAerolineas");

            migrationBuilder.DropForeignKey(
                name: "FK_Paises_AspNetUsers_userUpdateId",
                table: "Paises");

            migrationBuilder.DropForeignKey(
                name: "FK_Tripulaciones_AspNetUsers_userUpdateId",
                table: "Tripulaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_VueloClases_AspNetUsers_userUpdateId",
                table: "VueloClases");

            migrationBuilder.DropForeignKey(
                name: "FK_Vuelos_AspNetUsers_userUpdateId",
                table: "Vuelos");

            migrationBuilder.AlterColumn<string>(
                name: "userUpdateId",
                table: "Vuelos",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "userUpdateId",
                table: "VueloClases",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "userUpdateId",
                table: "Tripulaciones",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "userUpdateId",
                table: "Paises",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "userUpdateId",
                table: "ModeloAvionAerolineas",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "userUpdateId",
                table: "Empleados",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "userUpdateId",
                table: "Clientes",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "userUpdateId",
                table: "CatalogoTipos",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "userUpdateId",
                table: "Catalogos",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "userUpdateId",
                table: "Boletos",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "userUpdateId",
                table: "BitacoraEncabezados",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "userUpdateId",
                table: "BitacoraCuerpos",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "userUpdateId",
                table: "Aviones",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "userUpdateId",
                table: "AspNetRoles",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "userUpdateId",
                table: "Asientos",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "userUpdateId",
                table: "Aeropuertos",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "userUpdateId",
                table: "Aerolineas",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "userUpdateId",
                table: "AerolineaAeropuertos",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_AerolineaAeropuertos_AspNetUsers_userUpdateId",
                table: "AerolineaAeropuertos",
                column: "userUpdateId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Aerolineas_AspNetUsers_userUpdateId",
                table: "Aerolineas",
                column: "userUpdateId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Aeropuertos_AspNetUsers_userUpdateId",
                table: "Aeropuertos",
                column: "userUpdateId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Asientos_AspNetUsers_userUpdateId",
                table: "Asientos",
                column: "userUpdateId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_userUpdateId",
                table: "AspNetRoles",
                column: "userUpdateId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Aviones_AspNetUsers_userUpdateId",
                table: "Aviones",
                column: "userUpdateId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BitacoraCuerpos_AspNetUsers_userUpdateId",
                table: "BitacoraCuerpos",
                column: "userUpdateId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BitacoraEncabezados_AspNetUsers_userUpdateId",
                table: "BitacoraEncabezados",
                column: "userUpdateId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Boletos_AspNetUsers_userUpdateId",
                table: "Boletos",
                column: "userUpdateId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Catalogos_AspNetUsers_userUpdateId",
                table: "Catalogos",
                column: "userUpdateId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CatalogoTipos_AspNetUsers_userUpdateId",
                table: "CatalogoTipos",
                column: "userUpdateId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_AspNetUsers_userUpdateId",
                table: "Clientes",
                column: "userUpdateId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_AspNetUsers_userUpdateId",
                table: "Empleados",
                column: "userUpdateId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ModeloAvionAerolineas_AspNetUsers_userUpdateId",
                table: "ModeloAvionAerolineas",
                column: "userUpdateId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Paises_AspNetUsers_userUpdateId",
                table: "Paises",
                column: "userUpdateId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tripulaciones_AspNetUsers_userUpdateId",
                table: "Tripulaciones",
                column: "userUpdateId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VueloClases_AspNetUsers_userUpdateId",
                table: "VueloClases",
                column: "userUpdateId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vuelos_AspNetUsers_userUpdateId",
                table: "Vuelos",
                column: "userUpdateId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AerolineaAeropuertos_AspNetUsers_userUpdateId",
                table: "AerolineaAeropuertos");

            migrationBuilder.DropForeignKey(
                name: "FK_Aerolineas_AspNetUsers_userUpdateId",
                table: "Aerolineas");

            migrationBuilder.DropForeignKey(
                name: "FK_Aeropuertos_AspNetUsers_userUpdateId",
                table: "Aeropuertos");

            migrationBuilder.DropForeignKey(
                name: "FK_Asientos_AspNetUsers_userUpdateId",
                table: "Asientos");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_userUpdateId",
                table: "AspNetRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Aviones_AspNetUsers_userUpdateId",
                table: "Aviones");

            migrationBuilder.DropForeignKey(
                name: "FK_BitacoraCuerpos_AspNetUsers_userUpdateId",
                table: "BitacoraCuerpos");

            migrationBuilder.DropForeignKey(
                name: "FK_BitacoraEncabezados_AspNetUsers_userUpdateId",
                table: "BitacoraEncabezados");

            migrationBuilder.DropForeignKey(
                name: "FK_Boletos_AspNetUsers_userUpdateId",
                table: "Boletos");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalogos_AspNetUsers_userUpdateId",
                table: "Catalogos");

            migrationBuilder.DropForeignKey(
                name: "FK_CatalogoTipos_AspNetUsers_userUpdateId",
                table: "CatalogoTipos");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_AspNetUsers_userUpdateId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_AspNetUsers_userUpdateId",
                table: "Empleados");

            migrationBuilder.DropForeignKey(
                name: "FK_ModeloAvionAerolineas_AspNetUsers_userUpdateId",
                table: "ModeloAvionAerolineas");

            migrationBuilder.DropForeignKey(
                name: "FK_Paises_AspNetUsers_userUpdateId",
                table: "Paises");

            migrationBuilder.DropForeignKey(
                name: "FK_Tripulaciones_AspNetUsers_userUpdateId",
                table: "Tripulaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_VueloClases_AspNetUsers_userUpdateId",
                table: "VueloClases");

            migrationBuilder.DropForeignKey(
                name: "FK_Vuelos_AspNetUsers_userUpdateId",
                table: "Vuelos");

            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "userUpdateId",
                keyValue: null,
                column: "userUpdateId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "userUpdateId",
                table: "Vuelos",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "VueloClases",
                keyColumn: "userUpdateId",
                keyValue: null,
                column: "userUpdateId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "userUpdateId",
                table: "VueloClases",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Tripulaciones",
                keyColumn: "userUpdateId",
                keyValue: null,
                column: "userUpdateId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "userUpdateId",
                table: "Tripulaciones",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "userUpdateId",
                keyValue: null,
                column: "userUpdateId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "userUpdateId",
                table: "Paises",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "ModeloAvionAerolineas",
                keyColumn: "userUpdateId",
                keyValue: null,
                column: "userUpdateId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "userUpdateId",
                table: "ModeloAvionAerolineas",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Empleados",
                keyColumn: "userUpdateId",
                keyValue: null,
                column: "userUpdateId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "userUpdateId",
                table: "Empleados",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "userUpdateId",
                keyValue: null,
                column: "userUpdateId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "userUpdateId",
                table: "Clientes",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "CatalogoTipos",
                keyColumn: "userUpdateId",
                keyValue: null,
                column: "userUpdateId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "userUpdateId",
                table: "CatalogoTipos",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Catalogos",
                keyColumn: "userUpdateId",
                keyValue: null,
                column: "userUpdateId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "userUpdateId",
                table: "Catalogos",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Boletos",
                keyColumn: "userUpdateId",
                keyValue: null,
                column: "userUpdateId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "userUpdateId",
                table: "Boletos",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "BitacoraEncabezados",
                keyColumn: "userUpdateId",
                keyValue: null,
                column: "userUpdateId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "userUpdateId",
                table: "BitacoraEncabezados",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "BitacoraCuerpos",
                keyColumn: "userUpdateId",
                keyValue: null,
                column: "userUpdateId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "userUpdateId",
                table: "BitacoraCuerpos",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Aviones",
                keyColumn: "userUpdateId",
                keyValue: null,
                column: "userUpdateId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "userUpdateId",
                table: "Aviones",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "userUpdateId",
                keyValue: null,
                column: "userUpdateId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "userUpdateId",
                table: "AspNetRoles",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "userUpdateId",
                keyValue: null,
                column: "userUpdateId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "userUpdateId",
                table: "Asientos",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Aeropuertos",
                keyColumn: "userUpdateId",
                keyValue: null,
                column: "userUpdateId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "userUpdateId",
                table: "Aeropuertos",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Aerolineas",
                keyColumn: "userUpdateId",
                keyValue: null,
                column: "userUpdateId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "userUpdateId",
                table: "Aerolineas",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AerolineaAeropuertos",
                keyColumn: "userUpdateId",
                keyValue: null,
                column: "userUpdateId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "userUpdateId",
                table: "AerolineaAeropuertos",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_AerolineaAeropuertos_AspNetUsers_userUpdateId",
                table: "AerolineaAeropuertos",
                column: "userUpdateId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Aerolineas_AspNetUsers_userUpdateId",
                table: "Aerolineas",
                column: "userUpdateId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Aeropuertos_AspNetUsers_userUpdateId",
                table: "Aeropuertos",
                column: "userUpdateId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Asientos_AspNetUsers_userUpdateId",
                table: "Asientos",
                column: "userUpdateId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_userUpdateId",
                table: "AspNetRoles",
                column: "userUpdateId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Aviones_AspNetUsers_userUpdateId",
                table: "Aviones",
                column: "userUpdateId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BitacoraCuerpos_AspNetUsers_userUpdateId",
                table: "BitacoraCuerpos",
                column: "userUpdateId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BitacoraEncabezados_AspNetUsers_userUpdateId",
                table: "BitacoraEncabezados",
                column: "userUpdateId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Boletos_AspNetUsers_userUpdateId",
                table: "Boletos",
                column: "userUpdateId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalogos_AspNetUsers_userUpdateId",
                table: "Catalogos",
                column: "userUpdateId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CatalogoTipos_AspNetUsers_userUpdateId",
                table: "CatalogoTipos",
                column: "userUpdateId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_AspNetUsers_userUpdateId",
                table: "Clientes",
                column: "userUpdateId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_AspNetUsers_userUpdateId",
                table: "Empleados",
                column: "userUpdateId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModeloAvionAerolineas_AspNetUsers_userUpdateId",
                table: "ModeloAvionAerolineas",
                column: "userUpdateId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Paises_AspNetUsers_userUpdateId",
                table: "Paises",
                column: "userUpdateId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tripulaciones_AspNetUsers_userUpdateId",
                table: "Tripulaciones",
                column: "userUpdateId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VueloClases_AspNetUsers_userUpdateId",
                table: "VueloClases",
                column: "userUpdateId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vuelos_AspNetUsers_userUpdateId",
                table: "Vuelos",
                column: "userUpdateId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
