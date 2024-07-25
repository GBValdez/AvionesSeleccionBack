using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AvionesBackNet.Migrations
{
    /// <inheritdoc />
    public partial class NuevaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    userUpdateId = table.Column<string>(type: "text", nullable: true),
                    deleteAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    createAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_AspNetUsers_userUpdateId",
                        column: x => x.userUpdateId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    userUpdateId = table.Column<string>(type: "text", nullable: true),
                    deleteAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    createAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoles_AspNetUsers_userUpdateId",
                        column: x => x.userUpdateId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BitacoraEncabezados",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tabla = table.Column<string>(type: "text", nullable: false),
                    IdRegistro = table.Column<string>(type: "text", nullable: false),
                    TipoTransaccion = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    userUpdateId = table.Column<string>(type: "text", nullable: true),
                    deleteAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    createAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BitacoraEncabezados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BitacoraEncabezados_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BitacoraEncabezados_AspNetUsers_userUpdateId",
                        column: x => x.userUpdateId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CatalogoTipos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    userUpdateId = table.Column<string>(type: "text", nullable: true),
                    deleteAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    createAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogoTipos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatalogoTipos_AspNetUsers_userUpdateId",
                        column: x => x.userUpdateId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    PhoneCode = table.Column<string>(type: "text", nullable: false),
                    Iso3166 = table.Column<string>(type: "text", nullable: false),
                    Iso4217 = table.Column<string>(type: "text", nullable: false),
                    userUpdateId = table.Column<string>(type: "text", nullable: true),
                    deleteAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    createAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paises_AspNetUsers_userUpdateId",
                        column: x => x.userUpdateId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BitacoraCuerpos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Campo = table.Column<string>(type: "text", nullable: false),
                    ValorAnterior = table.Column<string>(type: "text", nullable: false),
                    ValorNuevo = table.Column<string>(type: "text", nullable: false),
                    BitacoraEncabezadoId = table.Column<long>(type: "bigint", nullable: false),
                    userUpdateId = table.Column<string>(type: "text", nullable: true),
                    deleteAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    createAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BitacoraCuerpos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BitacoraCuerpos_AspNetUsers_userUpdateId",
                        column: x => x.userUpdateId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BitacoraCuerpos_BitacoraEncabezados_BitacoraEncabezadoId",
                        column: x => x.BitacoraEncabezadoId,
                        principalTable: "BitacoraEncabezados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Catalogos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    CatalogoTipoId = table.Column<long>(type: "bigint", nullable: false),
                    userUpdateId = table.Column<string>(type: "text", nullable: true),
                    deleteAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    createAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalogos_AspNetUsers_userUpdateId",
                        column: x => x.userUpdateId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Catalogos_CatalogoTipos_CatalogoTipoId",
                        column: x => x.CatalogoTipoId,
                        principalTable: "CatalogoTipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aerolineas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Codigo = table.Column<string>(type: "text", nullable: false),
                    Direccion = table.Column<string>(type: "text", nullable: false),
                    Telefono = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PaisId = table.Column<long>(type: "bigint", nullable: false),
                    userUpdateId = table.Column<string>(type: "text", nullable: true),
                    deleteAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    createAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aerolineas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aerolineas_AspNetUsers_userUpdateId",
                        column: x => x.userUpdateId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Aerolineas_Paises_PaisId",
                        column: x => x.PaisId,
                        principalTable: "Paises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NoPasaporte = table.Column<string>(type: "text", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    FechaNacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    Correo = table.Column<string>(type: "text", nullable: false),
                    Telefono = table.Column<string>(type: "text", nullable: false),
                    TelefonoEmergencia = table.Column<string>(type: "text", nullable: false),
                    Direccion = table.Column<string>(type: "text", nullable: false),
                    PaisId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    CodigoTelefono = table.Column<long>(type: "bigint", nullable: false),
                    CodigoTelefonoEmergencia = table.Column<long>(type: "bigint", nullable: false),
                    PaiseId = table.Column<long>(type: "bigint", nullable: true),
                    userUpdateId = table.Column<string>(type: "text", nullable: true),
                    deleteAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    createAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clientes_AspNetUsers_userUpdateId",
                        column: x => x.userUpdateId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Clientes_Paises_CodigoTelefono",
                        column: x => x.CodigoTelefono,
                        principalTable: "Paises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clientes_Paises_CodigoTelefonoEmergencia",
                        column: x => x.CodigoTelefonoEmergencia,
                        principalTable: "Paises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clientes_Paises_PaisId",
                        column: x => x.PaisId,
                        principalTable: "Paises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clientes_Paises_PaiseId",
                        column: x => x.PaiseId,
                        principalTable: "Paises",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Aeropuertos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Iata = table.Column<string>(type: "text", nullable: false),
                    Oaci = table.Column<string>(type: "text", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Ciudad = table.Column<string>(type: "text", nullable: false),
                    Localidad = table.Column<string>(type: "text", nullable: false),
                    Latitud = table.Column<string>(type: "text", nullable: true),
                    Longitud = table.Column<string>(type: "text", nullable: true),
                    Telefono = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Activo = table.Column<bool>(type: "boolean", nullable: true),
                    Interno = table.Column<bool>(type: "boolean", nullable: true),
                    ZonaHorariaId = table.Column<long>(type: "bigint", nullable: false),
                    PaisId = table.Column<long>(type: "bigint", nullable: false),
                    userUpdateId = table.Column<string>(type: "text", nullable: true),
                    deleteAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    createAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aeropuertos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aeropuertos_AspNetUsers_userUpdateId",
                        column: x => x.userUpdateId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Aeropuertos_Catalogos_ZonaHorariaId",
                        column: x => x.ZonaHorariaId,
                        principalTable: "Catalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aeropuertos_Paises_PaisId",
                        column: x => x.PaisId,
                        principalTable: "Paises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aviones",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Codigo = table.Column<string>(type: "text", nullable: false),
                    Year = table.Column<string>(type: "text", nullable: false),
                    Serie = table.Column<string>(type: "text", nullable: false),
                    CapacidadCarga = table.Column<decimal>(type: "numeric", nullable: false),
                    CapacidadPasajeros = table.Column<decimal>(type: "numeric", nullable: false),
                    CapacidadCombustible = table.Column<decimal>(type: "numeric", nullable: false),
                    TamAsientoPorc = table.Column<decimal>(type: "numeric", nullable: false),
                    MarcaId = table.Column<long>(type: "bigint", nullable: false),
                    AerolineaId = table.Column<long>(type: "bigint", nullable: false),
                    ModeloId = table.Column<long>(type: "bigint", nullable: false),
                    TipoAvionId = table.Column<long>(type: "bigint", nullable: false),
                    EstadoId = table.Column<long>(type: "bigint", nullable: false),
                    userUpdateId = table.Column<string>(type: "text", nullable: true),
                    deleteAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    createAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aviones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aviones_Aerolineas_AerolineaId",
                        column: x => x.AerolineaId,
                        principalTable: "Aerolineas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aviones_AspNetUsers_userUpdateId",
                        column: x => x.userUpdateId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Aviones_Catalogos_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Catalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aviones_Catalogos_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Catalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aviones_Catalogos_ModeloId",
                        column: x => x.ModeloId,
                        principalTable: "Catalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aviones_Catalogos_TipoAvionId",
                        column: x => x.TipoAvionId,
                        principalTable: "Catalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AerolineaAeropuertos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AerolineaId = table.Column<long>(type: "bigint", nullable: false),
                    AeropuertoId = table.Column<long>(type: "bigint", nullable: false),
                    IsDestino = table.Column<bool>(type: "boolean", nullable: false),
                    userUpdateId = table.Column<string>(type: "text", nullable: true),
                    deleteAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    createAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AerolineaAeropuertos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AerolineaAeropuertos_Aerolineas_AerolineaId",
                        column: x => x.AerolineaId,
                        principalTable: "Aerolineas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AerolineaAeropuertos_Aeropuertos_AeropuertoId",
                        column: x => x.AeropuertoId,
                        principalTable: "Aeropuertos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AerolineaAeropuertos_AspNetUsers_userUpdateId",
                        column: x => x.userUpdateId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Asientos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Codigo = table.Column<string>(type: "text", nullable: false),
                    Posicion = table.Column<string>(type: "text", nullable: false),
                    ClaseId = table.Column<long>(type: "bigint", nullable: false),
                    AvionId = table.Column<long>(type: "bigint", nullable: false),
                    userUpdateId = table.Column<string>(type: "text", nullable: true),
                    deleteAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    createAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Asientos_AspNetUsers_userUpdateId",
                        column: x => x.userUpdateId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Asientos_Aviones_AvionId",
                        column: x => x.AvionId,
                        principalTable: "Aviones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asientos_Catalogos_ClaseId",
                        column: x => x.ClaseId,
                        principalTable: "Catalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tripulaciones",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Codigo = table.Column<string>(type: "text", nullable: false),
                    AerolineaId = table.Column<long>(type: "bigint", nullable: false),
                    AvionId = table.Column<long>(type: "bigint", nullable: true),
                    userUpdateId = table.Column<string>(type: "text", nullable: true),
                    deleteAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    createAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tripulaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tripulaciones_Aerolineas_AerolineaId",
                        column: x => x.AerolineaId,
                        principalTable: "Aerolineas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tripulaciones_AspNetUsers_userUpdateId",
                        column: x => x.userUpdateId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tripulaciones_Aviones_AvionId",
                        column: x => x.AvionId,
                        principalTable: "Aviones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Vuelos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Codigo = table.Column<string>(type: "text", nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaLlegada = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AvionId = table.Column<long>(type: "bigint", nullable: false),
                    AeropuertoOrigenId = table.Column<long>(type: "bigint", nullable: false),
                    AeropuertoDestinoId = table.Column<long>(type: "bigint", nullable: false),
                    userUpdateId = table.Column<string>(type: "text", nullable: true),
                    deleteAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    createAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vuelos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vuelos_Aeropuertos_AeropuertoDestinoId",
                        column: x => x.AeropuertoDestinoId,
                        principalTable: "Aeropuertos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vuelos_Aeropuertos_AeropuertoOrigenId",
                        column: x => x.AeropuertoOrigenId,
                        principalTable: "Aeropuertos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vuelos_AspNetUsers_userUpdateId",
                        column: x => x.userUpdateId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vuelos_Aviones_AvionId",
                        column: x => x.AvionId,
                        principalTable: "Aviones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    FechaNacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    Correo = table.Column<string>(type: "text", nullable: false),
                    Direccion = table.Column<string>(type: "text", nullable: false),
                    Telefono = table.Column<string>(type: "text", nullable: false),
                    PaisId = table.Column<long>(type: "bigint", nullable: false),
                    PuestoId = table.Column<long>(type: "bigint", nullable: false),
                    TripulacionId = table.Column<long>(type: "bigint", nullable: true),
                    AerolineaId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    userUpdateId = table.Column<string>(type: "text", nullable: true),
                    deleteAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    createAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empleados_Aerolineas_AerolineaId",
                        column: x => x.AerolineaId,
                        principalTable: "Aerolineas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Empleados_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Empleados_AspNetUsers_userUpdateId",
                        column: x => x.userUpdateId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Empleados_Catalogos_PuestoId",
                        column: x => x.PuestoId,
                        principalTable: "Catalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Empleados_Paises_PaisId",
                        column: x => x.PaisId,
                        principalTable: "Paises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Empleados_Tripulaciones_TripulacionId",
                        column: x => x.TripulacionId,
                        principalTable: "Tripulaciones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Boletos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Codigo = table.Column<string>(type: "text", nullable: false),
                    CantidadMaletasPresentadas = table.Column<int>(type: "integer", nullable: false),
                    EstadoBoletoId = table.Column<long>(type: "bigint", nullable: false),
                    VueloId = table.Column<long>(type: "bigint", nullable: false),
                    AsientoId = table.Column<long>(type: "bigint", nullable: false),
                    ClienteId = table.Column<long>(type: "bigint", nullable: false),
                    ClaseId = table.Column<long>(type: "bigint", nullable: false),
                    userUpdateId = table.Column<string>(type: "text", nullable: true),
                    deleteAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    createAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boletos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Boletos_Asientos_AsientoId",
                        column: x => x.AsientoId,
                        principalTable: "Asientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Boletos_AspNetUsers_userUpdateId",
                        column: x => x.userUpdateId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Boletos_Catalogos_ClaseId",
                        column: x => x.ClaseId,
                        principalTable: "Catalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Boletos_Catalogos_EstadoBoletoId",
                        column: x => x.EstadoBoletoId,
                        principalTable: "Catalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Boletos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Boletos_Vuelos_VueloId",
                        column: x => x.VueloId,
                        principalTable: "Vuelos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VueloClases",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClaseId = table.Column<long>(type: "bigint", nullable: false),
                    VueloId = table.Column<long>(type: "bigint", nullable: false),
                    Precio = table.Column<decimal>(type: "numeric", nullable: false),
                    CantidadMaletasMax = table.Column<int>(type: "integer", nullable: false),
                    userUpdateId = table.Column<string>(type: "text", nullable: true),
                    deleteAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    createAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VueloClases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VueloClases_AspNetUsers_userUpdateId",
                        column: x => x.userUpdateId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VueloClases_Catalogos_ClaseId",
                        column: x => x.ClaseId,
                        principalTable: "Catalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VueloClases_Vuelos_VueloId",
                        column: x => x.VueloId,
                        principalTable: "Vuelos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AerolineaAeropuertos_AerolineaId",
                table: "AerolineaAeropuertos",
                column: "AerolineaId");

            migrationBuilder.CreateIndex(
                name: "IX_AerolineaAeropuertos_AeropuertoId",
                table: "AerolineaAeropuertos",
                column: "AeropuertoId");

            migrationBuilder.CreateIndex(
                name: "IX_AerolineaAeropuertos_userUpdateId",
                table: "AerolineaAeropuertos",
                column: "userUpdateId");

            migrationBuilder.CreateIndex(
                name: "IX_Aerolineas_PaisId",
                table: "Aerolineas",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Aerolineas_userUpdateId",
                table: "Aerolineas",
                column: "userUpdateId");

            migrationBuilder.CreateIndex(
                name: "IX_Aeropuertos_PaisId",
                table: "Aeropuertos",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Aeropuertos_userUpdateId",
                table: "Aeropuertos",
                column: "userUpdateId");

            migrationBuilder.CreateIndex(
                name: "IX_Aeropuertos_ZonaHorariaId",
                table: "Aeropuertos",
                column: "ZonaHorariaId");

            migrationBuilder.CreateIndex(
                name: "IX_Asientos_AvionId",
                table: "Asientos",
                column: "AvionId");

            migrationBuilder.CreateIndex(
                name: "IX_Asientos_ClaseId",
                table: "Asientos",
                column: "ClaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Asientos_userUpdateId",
                table: "Asientos",
                column: "userUpdateId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_userUpdateId",
                table: "AspNetRoles",
                column: "userUpdateId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_userUpdateId",
                table: "AspNetUsers",
                column: "userUpdateId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Aviones_AerolineaId",
                table: "Aviones",
                column: "AerolineaId");

            migrationBuilder.CreateIndex(
                name: "IX_Aviones_EstadoId",
                table: "Aviones",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Aviones_MarcaId",
                table: "Aviones",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Aviones_ModeloId",
                table: "Aviones",
                column: "ModeloId");

            migrationBuilder.CreateIndex(
                name: "IX_Aviones_TipoAvionId",
                table: "Aviones",
                column: "TipoAvionId");

            migrationBuilder.CreateIndex(
                name: "IX_Aviones_userUpdateId",
                table: "Aviones",
                column: "userUpdateId");

            migrationBuilder.CreateIndex(
                name: "IX_BitacoraCuerpos_BitacoraEncabezadoId",
                table: "BitacoraCuerpos",
                column: "BitacoraEncabezadoId");

            migrationBuilder.CreateIndex(
                name: "IX_BitacoraCuerpos_userUpdateId",
                table: "BitacoraCuerpos",
                column: "userUpdateId");

            migrationBuilder.CreateIndex(
                name: "IX_BitacoraEncabezados_UserId",
                table: "BitacoraEncabezados",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BitacoraEncabezados_userUpdateId",
                table: "BitacoraEncabezados",
                column: "userUpdateId");

            migrationBuilder.CreateIndex(
                name: "IX_Boletos_AsientoId",
                table: "Boletos",
                column: "AsientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Boletos_ClaseId",
                table: "Boletos",
                column: "ClaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Boletos_ClienteId",
                table: "Boletos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Boletos_EstadoBoletoId",
                table: "Boletos",
                column: "EstadoBoletoId");

            migrationBuilder.CreateIndex(
                name: "IX_Boletos_userUpdateId",
                table: "Boletos",
                column: "userUpdateId");

            migrationBuilder.CreateIndex(
                name: "IX_Boletos_VueloId",
                table: "Boletos",
                column: "VueloId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalogos_CatalogoTipoId",
                table: "Catalogos",
                column: "CatalogoTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalogos_userUpdateId",
                table: "Catalogos",
                column: "userUpdateId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogoTipos_userUpdateId",
                table: "CatalogoTipos",
                column: "userUpdateId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_PaisId",
                table: "Clientes",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_UserId",
                table: "Clientes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_userUpdateId",
                table: "Clientes",
                column: "userUpdateId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_AerolineaId",
                table: "Empleados",
                column: "AerolineaId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_PaisId",
                table: "Empleados",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_PuestoId",
                table: "Empleados",
                column: "PuestoId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_TripulacionId",
                table: "Empleados",
                column: "TripulacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_UserId",
                table: "Empleados",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_userUpdateId",
                table: "Empleados",
                column: "userUpdateId");

            migrationBuilder.CreateIndex(
                name: "IX_Paises_userUpdateId",
                table: "Paises",
                column: "userUpdateId");

            migrationBuilder.CreateIndex(
                name: "IX_Tripulaciones_AerolineaId",
                table: "Tripulaciones",
                column: "AerolineaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tripulaciones_AvionId",
                table: "Tripulaciones",
                column: "AvionId");

            migrationBuilder.CreateIndex(
                name: "IX_Tripulaciones_userUpdateId",
                table: "Tripulaciones",
                column: "userUpdateId");

            migrationBuilder.CreateIndex(
                name: "IX_VueloClases_ClaseId",
                table: "VueloClases",
                column: "ClaseId");

            migrationBuilder.CreateIndex(
                name: "IX_VueloClases_userUpdateId",
                table: "VueloClases",
                column: "userUpdateId");

            migrationBuilder.CreateIndex(
                name: "IX_VueloClases_VueloId",
                table: "VueloClases",
                column: "VueloId");

            migrationBuilder.CreateIndex(
                name: "IX_Vuelos_AeropuertoDestinoId",
                table: "Vuelos",
                column: "AeropuertoDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vuelos_AeropuertoOrigenId",
                table: "Vuelos",
                column: "AeropuertoOrigenId");

            migrationBuilder.CreateIndex(
                name: "IX_Vuelos_AvionId",
                table: "Vuelos",
                column: "AvionId");

            migrationBuilder.CreateIndex(
                name: "IX_Vuelos_userUpdateId",
                table: "Vuelos",
                column: "userUpdateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AerolineaAeropuertos");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BitacoraCuerpos");

            migrationBuilder.DropTable(
                name: "Boletos");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "VueloClases");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "BitacoraEncabezados");

            migrationBuilder.DropTable(
                name: "Asientos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Tripulaciones");

            migrationBuilder.DropTable(
                name: "Vuelos");

            migrationBuilder.DropTable(
                name: "Aeropuertos");

            migrationBuilder.DropTable(
                name: "Aviones");

            migrationBuilder.DropTable(
                name: "Aerolineas");

            migrationBuilder.DropTable(
                name: "Catalogos");

            migrationBuilder.DropTable(
                name: "Paises");

            migrationBuilder.DropTable(
                name: "CatalogoTipos");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
