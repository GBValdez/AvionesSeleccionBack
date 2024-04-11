using System;
using System.Collections.Generic;

namespace AvionesBackNet.Models;

public partial class Catalogo
{
    public ulong Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public ulong CatalogoTipoId { get; set; }

    public virtual ICollection<Aerolinea> Aerolineas { get; set; } = new List<Aerolinea>();

    public virtual ICollection<Aeropuerto> Aeropuertos { get; set; } = new List<Aeropuerto>();

    public virtual ICollection<Asiento> Asientos { get; set; } = new List<Asiento>();

    public virtual ICollection<Avione> AvioneEstados { get; set; } = new List<Avione>();

    public virtual ICollection<Avione> AvioneMarcas { get; set; } = new List<Avione>();

    public virtual ICollection<Avione> AvioneModelos { get; set; } = new List<Avione>();

    public virtual ICollection<Avione> AvioneTipos { get; set; } = new List<Avione>();

    public virtual ICollection<Boleto> Boletos { get; set; } = new List<Boleto>();

    public virtual CatalogoTipo CatalogoTipo { get; set; } = null!;

    public virtual ICollection<Cliente> ClienteCodigoTelefonoEmergenciaNavigations { get; set; } = new List<Cliente>();

    public virtual ICollection<Cliente> ClienteCodigoTelefonoNavigations { get; set; } = new List<Cliente>();

    public virtual ICollection<Cliente> ClientePais { get; set; } = new List<Cliente>();

    public virtual ICollection<Empleado> EmpleadoPais { get; set; } = new List<Empleado>();

    public virtual ICollection<Empleado> EmpleadoPuestos { get; set; } = new List<Empleado>();

    public virtual ICollection<ModeloAvionAerolinea> ModeloAvionAerolineas { get; set; } = new List<ModeloAvionAerolinea>();

    public virtual ICollection<VueloClase> VueloClases { get; set; } = new List<VueloClase>();
}
