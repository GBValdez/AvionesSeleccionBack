using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace AvionesBackNet.Models;

public partial class AvionesContext : DbContext
{
    public AvionesContext()
    {
    }

    public AvionesContext(DbContextOptions<AvionesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aerolinea> Aerolineas { get; set; }

    public virtual DbSet<AerolineaAeropuerto> AerolineaAeropuertos { get; set; }

    public virtual DbSet<Aeropuerto> Aeropuertos { get; set; }

    public virtual DbSet<Asiento> Asientos { get; set; }

    public virtual DbSet<Avione> Aviones { get; set; }

    public virtual DbSet<BitacoraCuerpo> BitacoraCuerpos { get; set; }

    public virtual DbSet<BitacoraEncabezado> BitacoraEncabezados { get; set; }

    public virtual DbSet<Boleto> Boletos { get; set; }

    public virtual DbSet<Catalogo> Catalogos { get; set; }

    public virtual DbSet<CatalogoTipo> CatalogoTipos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<FailedJob> FailedJobs { get; set; }

    public virtual DbSet<Migration> Migrations { get; set; }

    public virtual DbSet<ModeloAvionAerolinea> ModeloAvionAerolineas { get; set; }

    public virtual DbSet<PasswordResetToken> PasswordResetTokens { get; set; }

    public virtual DbSet<PersonalAccessToken> PersonalAccessTokens { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Tripulacione> Tripulaciones { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UsuarioRol> UsuarioRols { get; set; }

    public virtual DbSet<Vuelo> Vuelos { get; set; }

    public virtual DbSet<VueloClase> VueloClases { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=Aviones;user=root;password=admin", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.36-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Aerolinea>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("aerolineas")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.PaisId, "aerolineas_pais_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Codigo)
                .HasMaxLength(255)
                .HasColumnName("codigo");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
            entity.Property(e => e.PaisId).HasColumnName("pais_id");
            entity.Property(e => e.Telefono)
                .HasMaxLength(255)
                .HasColumnName("telefono");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Pais).WithMany(p => p.Aerolineas)
                .HasForeignKey(d => d.PaisId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("aerolineas_pais_id_foreign");
        });

        modelBuilder.Entity<AerolineaAeropuerto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("aerolinea_aeropuertos")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.AerolineaId, "aerolinea_aeropuertos_aerolinea_id_foreign");

            entity.HasIndex(e => e.AeropuertoId, "aerolinea_aeropuertos_aeropuerto_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AerolineaId).HasColumnName("aerolinea_id");
            entity.Property(e => e.AeropuertoId).HasColumnName("aeropuerto_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.IsDestino).HasColumnName("is_destino");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Aerolinea).WithMany(p => p.AerolineaAeropuertos)
                .HasForeignKey(d => d.AerolineaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("aerolinea_aeropuertos_aerolinea_id_foreign");

            entity.HasOne(d => d.Aeropuerto).WithMany(p => p.AerolineaAeropuertos)
                .HasForeignKey(d => d.AeropuertoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("aerolinea_aeropuertos_aeropuerto_id_foreign");
        });

        modelBuilder.Entity<Aeropuerto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("aeropuertos")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.PaisId, "aeropuertos_pais_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Activo)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("activo");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(255)
                .HasColumnName("ciudad");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Iata)
                .HasMaxLength(3)
                .HasColumnName("IATA");
            entity.Property(e => e.Interno)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("interno");
            entity.Property(e => e.Latitud)
                .HasMaxLength(255)
                .HasColumnName("latitud");
            entity.Property(e => e.Localidad)
                .HasMaxLength(255)
                .HasColumnName("localidad");
            entity.Property(e => e.Longitud)
                .HasMaxLength(255)
                .HasColumnName("longitud");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
            entity.Property(e => e.Oaci)
                .HasMaxLength(4)
                .HasColumnName("OACI");
            entity.Property(e => e.PaisId).HasColumnName("pais_id");
            entity.Property(e => e.Telefono)
                .HasMaxLength(255)
                .HasColumnName("telefono");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.ZonaHoraria)
                .HasMaxLength(255)
                .HasColumnName("zona_horaria");

            entity.HasOne(d => d.Pais).WithMany(p => p.Aeropuertos)
                .HasForeignKey(d => d.PaisId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("aeropuertos_pais_id_foreign");
        });

        modelBuilder.Entity<Asiento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("asientos")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.ClaseId, "asientos_clase_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AvionId).HasColumnName("avion_id");
            entity.Property(e => e.ClaseId).HasColumnName("clase_id");
            entity.Property(e => e.Codigo)
                .HasMaxLength(255)
                .HasColumnName("codigo");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Posicion)
                .HasMaxLength(255)
                .HasColumnName("posicion");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Clase).WithMany(p => p.Asientos)
                .HasForeignKey(d => d.ClaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("asientos_clase_id_foreign");
        });

        modelBuilder.Entity<Avione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("aviones")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.AerolineaId, "aviones_aerolinea_id_foreign");

            entity.HasIndex(e => e.EstadoId, "aviones_estado_id_foreign");

            entity.HasIndex(e => e.MarcaId, "aviones_marca_id_foreign");

            entity.HasIndex(e => e.ModeloId, "aviones_modelo_id_foreign");

            entity.HasIndex(e => e.TipoId, "aviones_tipo_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AerolineaId).HasColumnName("aerolinea_id");
            entity.Property(e => e.CapacidadCarga)
                .HasPrecision(10, 2)
                .HasColumnName("capacidad_carga");
            entity.Property(e => e.CapacidadCombustible)
                .HasPrecision(10, 2)
                .HasColumnName("capacidad_combustible");
            entity.Property(e => e.CapacidadPasajeros)
                .HasPrecision(10, 2)
                .HasColumnName("capacidad_pasajeros");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp")
                .HasColumnName("deleted_at");
            entity.Property(e => e.EstadoId).HasColumnName("estado_id");
            entity.Property(e => e.FechaEnsamble).HasColumnName("fecha_ensamble");
            entity.Property(e => e.MarcaId).HasColumnName("marca_id");
            entity.Property(e => e.ModeloId).HasColumnName("modelo_id");
            entity.Property(e => e.Serie)
                .HasMaxLength(255)
                .HasColumnName("serie");
            entity.Property(e => e.TamAsientoPorc)
                .HasPrecision(10, 2)
                .HasColumnName("tam_asiento_porc");
            entity.Property(e => e.TipoId).HasColumnName("tipo_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Aerolinea).WithMany(p => p.Aviones)
                .HasForeignKey(d => d.AerolineaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("aviones_aerolinea_id_foreign");

            entity.HasOne(d => d.Estado).WithMany(p => p.AvioneEstados)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("aviones_estado_id_foreign");

            entity.HasOne(d => d.Marca).WithMany(p => p.AvioneMarcas)
                .HasForeignKey(d => d.MarcaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("aviones_marca_id_foreign");

            entity.HasOne(d => d.Modelo).WithMany(p => p.AvioneModelos)
                .HasForeignKey(d => d.ModeloId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("aviones_modelo_id_foreign");

            entity.HasOne(d => d.Tipo).WithMany(p => p.AvioneTipos)
                .HasForeignKey(d => d.TipoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("aviones_tipo_id_foreign");
        });

        modelBuilder.Entity<BitacoraCuerpo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("bitacora_cuerpo")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.BitacoraEncabezadoId, "bitacora_cuerpo_bitacora_encabezado_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BitacoraEncabezadoId).HasColumnName("bitacora_encabezado_id");
            entity.Property(e => e.Campo)
                .HasMaxLength(255)
                .HasColumnName("campo");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp")
                .HasColumnName("deleted_at");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.ValorAnterior)
                .HasMaxLength(255)
                .HasColumnName("valor_anterior");
            entity.Property(e => e.ValorNuevo)
                .HasMaxLength(255)
                .HasColumnName("valor_nuevo");

            entity.HasOne(d => d.BitacoraEncabezado).WithMany(p => p.BitacoraCuerpos)
                .HasForeignKey(d => d.BitacoraEncabezadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("bitacora_cuerpo_bitacora_encabezado_id_foreign");
        });

        modelBuilder.Entity<BitacoraEncabezado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("bitacora_encabezado")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.UserId, "bitacora_encabezado_user_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp")
                .HasColumnName("deleted_at");
            entity.Property(e => e.IdRegistro)
                .HasMaxLength(255)
                .HasColumnName("id_registro");
            entity.Property(e => e.Tabla)
                .HasMaxLength(255)
                .HasColumnName("tabla");
            entity.Property(e => e.TipoTransaccion)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("tipo_transaccion");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.BitacoraEncabezados)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("bitacora_encabezado_user_id_foreign");
        });

        modelBuilder.Entity<Boleto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("boletos")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.AsientoId, "boletos_asiento_id_foreign");

            entity.HasIndex(e => e.ClienteId, "boletos_cliente_id_foreign");

            entity.HasIndex(e => e.EstadoBoletoId, "boletos_estado_boleto_id_foreign");

            entity.HasIndex(e => e.VueloId, "boletos_vuelo_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AsientoId).HasColumnName("asiento_id");
            entity.Property(e => e.CantidadMaletasAdquiridas).HasColumnName("cantidad_maletas_adquiridas");
            entity.Property(e => e.CantidadMaletasPresentadas).HasColumnName("cantidad_maletas_presentadas");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp")
                .HasColumnName("deleted_at");
            entity.Property(e => e.EstadoBoletoId).HasColumnName("estado_boleto_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.VueloId).HasColumnName("vuelo_id");

            entity.HasOne(d => d.Asiento).WithMany(p => p.Boletos)
                .HasForeignKey(d => d.AsientoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("boletos_asiento_id_foreign");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Boletos)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("boletos_cliente_id_foreign");

            entity.HasOne(d => d.EstadoBoleto).WithMany(p => p.Boletos)
                .HasForeignKey(d => d.EstadoBoletoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("boletos_estado_boleto_id_foreign");

            entity.HasOne(d => d.Vuelo).WithMany(p => p.Boletos)
                .HasForeignKey(d => d.VueloId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("boletos_vuelo_id_foreign");
        });

        modelBuilder.Entity<Catalogo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("catalogo")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.CatalogoTipoId, "catalogo_catalogo_tipo_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CatalogoTipoId).HasColumnName("catalogo_tipo_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.CatalogoTipo).WithMany(p => p.Catalogos)
                .HasForeignKey(d => d.CatalogoTipoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("catalogo_catalogo_tipo_id_foreign");
        });

        modelBuilder.Entity<CatalogoTipo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("catalogo_tipo")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("clientes")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.CodigoTelefonoEmergencia, "clientes_codigo_telefono_emergencia_foreign");

            entity.HasIndex(e => e.CodigoTelefono, "clientes_codigo_telefono_foreign");

            entity.HasIndex(e => e.PaisId, "clientes_pais_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CodigoTelefono).HasColumnName("codigo_telefono");
            entity.Property(e => e.CodigoTelefonoEmergencia).HasColumnName("codigo_telefono_emergencia");
            entity.Property(e => e.Correo)
                .HasMaxLength(255)
                .HasColumnName("correo");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .HasColumnName("direccion");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.NoPasaporte)
                .HasMaxLength(255)
                .HasColumnName("no_pasaporte");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
            entity.Property(e => e.PaisId).HasColumnName("pais_id");
            entity.Property(e => e.Telefono)
                .HasMaxLength(255)
                .HasColumnName("telefono");
            entity.Property(e => e.TelefonoEmergencia)
                .HasMaxLength(255)
                .HasColumnName("telefono_emergencia");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.CodigoTelefonoNavigation).WithMany(p => p.ClienteCodigoTelefonoNavigations)
                .HasForeignKey(d => d.CodigoTelefono)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("clientes_codigo_telefono_foreign");

            entity.HasOne(d => d.CodigoTelefonoEmergenciaNavigation).WithMany(p => p.ClienteCodigoTelefonoEmergenciaNavigations)
                .HasForeignKey(d => d.CodigoTelefonoEmergencia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("clientes_codigo_telefono_emergencia_foreign");

            entity.HasOne(d => d.Pais).WithMany(p => p.ClientePais)
                .HasForeignKey(d => d.PaisId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("clientes_pais_id_foreign");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("empleados")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.AerolineaId, "empleados_aerolinea_id_foreign");

            entity.HasIndex(e => e.PaisId, "empleados_pais_id_foreign");

            entity.HasIndex(e => e.PuestoId, "empleados_puesto_id_foreign");

            entity.HasIndex(e => e.TripulacionId, "empleados_tripulacion_id_foreign");

            entity.HasIndex(e => e.UserId, "empleados_user_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AerolineaId).HasColumnName("aerolinea_id");
            entity.Property(e => e.Correo)
                .HasMaxLength(255)
                .HasColumnName("correo");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .HasColumnName("direccion");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
            entity.Property(e => e.PaisId).HasColumnName("pais_id");
            entity.Property(e => e.PuestoId).HasColumnName("puesto_id");
            entity.Property(e => e.Telefono)
                .HasMaxLength(255)
                .HasColumnName("telefono");
            entity.Property(e => e.TripulacionId).HasColumnName("tripulacion_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Aerolinea).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.AerolineaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("empleados_aerolinea_id_foreign");

            entity.HasOne(d => d.Pais).WithMany(p => p.EmpleadoPais)
                .HasForeignKey(d => d.PaisId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("empleados_pais_id_foreign");

            entity.HasOne(d => d.Puesto).WithMany(p => p.EmpleadoPuestos)
                .HasForeignKey(d => d.PuestoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("empleados_puesto_id_foreign");

            entity.HasOne(d => d.Tripulacion).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.TripulacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("empleados_tripulacion_id_foreign");

            entity.HasOne(d => d.User).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("empleados_user_id_foreign");
        });

        modelBuilder.Entity<FailedJob>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("failed_jobs")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.Uuid, "failed_jobs_uuid_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Connection)
                .HasColumnType("text")
                .HasColumnName("connection");
            entity.Property(e => e.Exception).HasColumnName("exception");
            entity.Property(e => e.FailedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("failed_at");
            entity.Property(e => e.Payload).HasColumnName("payload");
            entity.Property(e => e.Queue)
                .HasColumnType("text")
                .HasColumnName("queue");
            entity.Property(e => e.Uuid).HasColumnName("uuid");
        });

        modelBuilder.Entity<Migration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("migrations")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Batch).HasColumnName("batch");
            entity.Property(e => e.Migration1)
                .HasMaxLength(255)
                .HasColumnName("migration");
        });

        modelBuilder.Entity<ModeloAvionAerolinea>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("modelo_avion_aerolineas")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.AerolineaId, "modelo_avion_aerolineas_aerolinea_id_foreign");

            entity.HasIndex(e => e.ModeloAvionId, "modelo_avion_aerolineas_modelo_avion_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AerolineaId).HasColumnName("aerolinea_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.ModeloAvionId).HasColumnName("modelo_avion_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Aerolinea).WithMany(p => p.ModeloAvionAerolineas)
                .HasForeignKey(d => d.AerolineaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("modelo_avion_aerolineas_aerolinea_id_foreign");

            entity.HasOne(d => d.ModeloAvion).WithMany(p => p.ModeloAvionAerolineas)
                .HasForeignKey(d => d.ModeloAvionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("modelo_avion_aerolineas_modelo_avion_id_foreign");
        });

        modelBuilder.Entity<PasswordResetToken>(entity =>
        {
            entity.HasKey(e => e.Email).HasName("PRIMARY");

            entity
                .ToTable("password_reset_tokens")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Token)
                .HasMaxLength(255)
                .HasColumnName("token");
        });

        modelBuilder.Entity<PersonalAccessToken>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("personal_access_tokens")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.Token, "personal_access_tokens_token_unique").IsUnique();

            entity.HasIndex(e => new { e.TokenableType, e.TokenableId }, "personal_access_tokens_tokenable_type_tokenable_id_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Abilities)
                .HasColumnType("text")
                .HasColumnName("abilities");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.ExpiresAt)
                .HasColumnType("timestamp")
                .HasColumnName("expires_at");
            entity.Property(e => e.LastUsedAt)
                .HasColumnType("timestamp")
                .HasColumnName("last_used_at");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Token)
                .HasMaxLength(64)
                .HasColumnName("token");
            entity.Property(e => e.TokenableId).HasColumnName("tokenable_id");
            entity.Property(e => e.TokenableType).HasColumnName("tokenable_type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("roles")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Tripulacione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tripulaciones")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.AerolineaId, "tripulaciones_aerolinea_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AerolineaId).HasColumnName("aerolinea_id");
            entity.Property(e => e.Codigo)
                .HasMaxLength(255)
                .HasColumnName("codigo");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp")
                .HasColumnName("deleted_at");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Aerolinea).WithMany(p => p.Tripulaciones)
                .HasForeignKey(d => d.AerolineaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tripulaciones_aerolinea_id_foreign");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("users")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.Email, "users_email_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.EmailVerifiedAt)
                .HasColumnType("timestamp")
                .HasColumnName("email_verified_at");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.RememberToken)
                .HasMaxLength(100)
                .HasColumnName("remember_token");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<UsuarioRol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("usuario_rols")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.RolId, "usuario_rols_rol_id_foreign");

            entity.HasIndex(e => e.UserId, "usuario_rols_user_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.RolId).HasColumnName("rol_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Rol).WithMany(p => p.UsuarioRols)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usuario_rols_rol_id_foreign");

            entity.HasOne(d => d.User).WithMany(p => p.UsuarioRols)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usuario_rols_user_id_foreign");
        });

        modelBuilder.Entity<Vuelo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("vuelos")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.AeropuertoDestinoId, "vuelos_aeropuerto_destino_id_foreign");

            entity.HasIndex(e => e.AeropuertoOrigenId, "vuelos_aeropuerto_origen_id_foreign");

            entity.HasIndex(e => e.AvionId, "vuelos_avion_id_foreign");

            entity.HasIndex(e => e.TripulacionId, "vuelos_tripulacion_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AeropuertoDestinoId).HasColumnName("aeropuerto_destino_id");
            entity.Property(e => e.AeropuertoOrigenId).HasColumnName("aeropuerto_origen_id");
            entity.Property(e => e.AvionId).HasColumnName("avion_id");
            entity.Property(e => e.Codigo)
                .HasMaxLength(255)
                .HasColumnName("codigo");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp")
                .HasColumnName("deleted_at");
            entity.Property(e => e.FechaLlegada)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_llegada");
            entity.Property(e => e.FechaSalida)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_salida");
            entity.Property(e => e.TripulacionId).HasColumnName("tripulacion_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.AeropuertoDestino).WithMany(p => p.VueloAeropuertoDestinos)
                .HasForeignKey(d => d.AeropuertoDestinoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("vuelos_aeropuerto_destino_id_foreign");

            entity.HasOne(d => d.AeropuertoOrigen).WithMany(p => p.VueloAeropuertoOrigens)
                .HasForeignKey(d => d.AeropuertoOrigenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("vuelos_aeropuerto_origen_id_foreign");

            entity.HasOne(d => d.Avion).WithMany(p => p.Vuelos)
                .HasForeignKey(d => d.AvionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("vuelos_avion_id_foreign");

            entity.HasOne(d => d.Tripulacion).WithMany(p => p.Vuelos)
                .HasForeignKey(d => d.TripulacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("vuelos_tripulacion_id_foreign");
        });

        modelBuilder.Entity<VueloClase>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("vuelo_clase")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.ClaseId, "vuelo_clase_clase_id_foreign");

            entity.HasIndex(e => e.VueloId, "vuelo_clase_vuelo_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClaseId).HasColumnName("clase_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Precio)
                .HasPrecision(10, 2)
                .HasColumnName("precio");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.VueloId).HasColumnName("vuelo_id");

            entity.HasOne(d => d.Clase).WithMany(p => p.VueloClases)
                .HasForeignKey(d => d.ClaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("vuelo_clase_clase_id_foreign");

            entity.HasOne(d => d.Vuelo).WithMany(p => p.VueloClases)
                .HasForeignKey(d => d.VueloId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("vuelo_clase_vuelo_id_foreign");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
