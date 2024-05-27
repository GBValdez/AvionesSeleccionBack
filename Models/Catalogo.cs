using System;
using System.Collections.Generic;
using AvionesBackNet.utils;

namespace AvionesBackNet.Models;

public partial class Catalogo : CommonsModel<long>
{
    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public long CatalogoTipoId { get; set; }

    public virtual ICollection<Asiento> Asientos { get; set; } = new List<Asiento>();

    public virtual ICollection<Avione> AvioneEstados { get; set; } = new List<Avione>();

    public virtual ICollection<Avione> AvioneMarcas { get; set; } = new List<Avione>();

    public virtual ICollection<Avione> AvioneModelos { get; set; } = new List<Avione>();

    public virtual ICollection<Avione> AvioneTipoAvions { get; set; } = new List<Avione>();

    public virtual ICollection<Boleto> Boletos { get; set; } = new List<Boleto>();

    public virtual CatalogoTipo CatalogoTipo { get; set; } = null!;

    public virtual ICollection<Cliente> ClienteCodigoTelefonoEmergenciaNavigations { get; set; } = new List<Cliente>();

    public virtual ICollection<Cliente> ClienteCodigoTelefonoNavigations { get; set; } = new List<Cliente>();

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    public virtual ICollection<ModeloAvionAerolinea> ModeloAvionAerolineas { get; set; } = new List<ModeloAvionAerolinea>();

    public virtual ICollection<VueloClase> VueloClases { get; set; } = new List<VueloClase>();
}
