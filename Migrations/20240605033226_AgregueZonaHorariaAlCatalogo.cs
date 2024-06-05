using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvionesBackNet.Migrations
{
    /// <inheritdoc />
    public partial class AgregueZonaHorariaAlCatalogo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModeloAvionAerolineas");

            migrationBuilder.DropColumn(
                name: "ZonaHoraria",
                table: "Aeropuertos");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "CatalogoTipos",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "CatalogoTipos",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Codigo",
                table: "CatalogoTipos",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Catalogos",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Catalogos",
                newName: "description");

            migrationBuilder.AddColumn<long>(
                name: "ZonaHorariaId",
                table: "Aeropuertos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Aeropuertos_ZonaHorariaId",
                table: "Aeropuertos",
                column: "ZonaHorariaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aeropuertos_Catalogos_ZonaHorariaId",
                table: "Aeropuertos",
                column: "ZonaHorariaId",
                principalTable: "Catalogos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aeropuertos_Catalogos_ZonaHorariaId",
                table: "Aeropuertos");

            migrationBuilder.DropIndex(
                name: "IX_Aeropuertos_ZonaHorariaId",
                table: "Aeropuertos");

            migrationBuilder.DropColumn(
                name: "ZonaHorariaId",
                table: "Aeropuertos");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "CatalogoTipos",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "CatalogoTipos",
                newName: "Descripcion");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "CatalogoTipos",
                newName: "Codigo");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Catalogos",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Catalogos",
                newName: "Descripcion");

            migrationBuilder.AddColumn<string>(
                name: "ZonaHoraria",
                table: "Aeropuertos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ModeloAvionAerolineas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AerolineaId = table.Column<long>(type: "bigint", nullable: false),
                    ModeloAvionId = table.Column<long>(type: "bigint", nullable: false),
                    userUpdateId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    createAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    deleteAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    updateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeloAvionAerolineas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModeloAvionAerolineas_Aerolineas_AerolineaId",
                        column: x => x.AerolineaId,
                        principalTable: "Aerolineas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModeloAvionAerolineas_AspNetUsers_userUpdateId",
                        column: x => x.userUpdateId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ModeloAvionAerolineas_Catalogos_ModeloAvionId",
                        column: x => x.ModeloAvionId,
                        principalTable: "Catalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ModeloAvionAerolineas_AerolineaId",
                table: "ModeloAvionAerolineas",
                column: "AerolineaId");

            migrationBuilder.CreateIndex(
                name: "IX_ModeloAvionAerolineas_ModeloAvionId",
                table: "ModeloAvionAerolineas",
                column: "ModeloAvionId");

            migrationBuilder.CreateIndex(
                name: "IX_ModeloAvionAerolineas_userUpdateId",
                table: "ModeloAvionAerolineas",
                column: "userUpdateId");
        }
    }
}
