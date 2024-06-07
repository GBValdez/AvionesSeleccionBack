using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using project.roles;
using project.users;

namespace AvionesBackNet.Models;

public partial class AvionesContext : IdentityDbContext<userEntity, rolEntity, string>
{
    IConfiguration _configuration;
    public AvionesContext(DbContextOptions<AvionesContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
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



    public virtual DbSet<Paise> Paises { get; set; }


    public virtual DbSet<Tripulacione> Tripulaciones { get; set; }



    public virtual DbSet<Vuelo> Vuelos { get; set; }

    public virtual DbSet<VueloClase> VueloClases { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuración de las relaciones
        modelBuilder.Entity<Cliente>()
            .HasOne(c => c.CodigoTelefonoEmergenciaObj)
            .WithMany()
            .HasForeignKey(c => c.CodigoTelefonoEmergencia)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Cliente>()
            .HasOne(c => c.CodigoTelefonoObj)
            .WithMany()
            .HasForeignKey(c => c.CodigoTelefono)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Cliente>()
            .HasOne(c => c.Pais)
            .WithMany()
            .HasForeignKey(c => c.PaisId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Cliente>()
            .HasOne(c => c.User)
            .WithMany()
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(modelBuilder);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql(_configuration.GetConnectionString("DefaultConnection")
        , ServerVersion.Parse(_configuration.GetConnectionString("mySqlVersion")));

}
