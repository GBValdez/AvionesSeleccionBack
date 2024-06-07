using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvionesBackNet.Migrations
{
    /// <inheritdoc />
    public partial class cambieLaRelacionDeLosCodigosAaaax : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asientos_Catalogos_EstadoId",
                table: "Asientos");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_AspNetUsers_UserId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Catalogos_CodigoTelefonoEmergenciaNavigationId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Catalogos_CodigoTelefonoNavigationId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Paises_PaisId",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_CodigoTelefonoEmergenciaNavigationId",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_CodigoTelefonoNavigationId",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Asientos_EstadoId",
                table: "Asientos");

            migrationBuilder.DropColumn(
                name: "CodigoTelefonoEmergenciaNavigationId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "CodigoTelefonoNavigationId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "Asientos");

            migrationBuilder.AddColumn<long>(
                name: "PaiseId",
                table: "Clientes",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_CodigoTelefono",
                table: "Clientes",
                column: "CodigoTelefono");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_CodigoTelefonoEmergencia",
                table: "Clientes",
                column: "CodigoTelefonoEmergencia");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_PaiseId",
                table: "Clientes",
                column: "PaiseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_AspNetUsers_UserId",
                table: "Clientes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Paises_CodigoTelefono",
                table: "Clientes",
                column: "CodigoTelefono",
                principalTable: "Paises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Paises_CodigoTelefonoEmergencia",
                table: "Clientes",
                column: "CodigoTelefonoEmergencia",
                principalTable: "Paises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Paises_PaisId",
                table: "Clientes",
                column: "PaisId",
                principalTable: "Paises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Paises_PaiseId",
                table: "Clientes",
                column: "PaiseId",
                principalTable: "Paises",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_AspNetUsers_UserId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Paises_CodigoTelefono",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Paises_CodigoTelefonoEmergencia",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Paises_PaisId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Paises_PaiseId",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_CodigoTelefono",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_CodigoTelefonoEmergencia",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_PaiseId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "PaiseId",
                table: "Clientes");

            migrationBuilder.AddColumn<long>(
                name: "CodigoTelefonoEmergenciaNavigationId",
                table: "Clientes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CodigoTelefonoNavigationId",
                table: "Clientes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "EstadoId",
                table: "Asientos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_CodigoTelefonoEmergenciaNavigationId",
                table: "Clientes",
                column: "CodigoTelefonoEmergenciaNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_CodigoTelefonoNavigationId",
                table: "Clientes",
                column: "CodigoTelefonoNavigationId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_AspNetUsers_UserId",
                table: "Clientes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Catalogos_CodigoTelefonoEmergenciaNavigationId",
                table: "Clientes",
                column: "CodigoTelefonoEmergenciaNavigationId",
                principalTable: "Catalogos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Catalogos_CodigoTelefonoNavigationId",
                table: "Clientes",
                column: "CodigoTelefonoNavigationId",
                principalTable: "Catalogos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Paises_PaisId",
                table: "Clientes",
                column: "PaisId",
                principalTable: "Paises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
