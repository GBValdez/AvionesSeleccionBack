using System;
using System.Collections.Generic;
using project.utils;

namespace AvionesBackNet.Models;

public partial class Cliente : CommonsModel<long>
{
    public string NoPasaporte { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public DateOnly FechaNacimiento { get; set; }

    public string Correo { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string TelefonoEmergencia { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public long PaisId { get; set; }

    public long CodigoTelefono { get; set; }

    public long CodigoTelefonoEmergencia { get; set; }
    public virtual ICollection<Boleto> Boletos { get; set; } = new List<Boleto>();

    public virtual Catalogo CodigoTelefonoEmergenciaNavigation { get; set; } = null!;

    public virtual Catalogo CodigoTelefonoNavigation { get; set; } = null!;

    public virtual Paise Pais { get; set; } = null!;
}
