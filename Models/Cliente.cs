using System;
using System.Collections.Generic;

namespace AvionesBackNet.Models;

public partial class Cliente
{
    public ulong Id { get; set; }

    public string NoPasaporte { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public DateOnly FechaNacimiento { get; set; }

    public string Correo { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string TelefonoEmergencia { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public ulong PaisId { get; set; }

    public ulong CodigoTelefono { get; set; }

    public ulong CodigoTelefonoEmergencia { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Boleto> Boletos { get; set; } = new List<Boleto>();

    public virtual Catalogo CodigoTelefonoEmergenciaNavigation { get; set; } = null!;

    public virtual Catalogo CodigoTelefonoNavigation { get; set; } = null!;

    public virtual Catalogo Pais { get; set; } = null!;
}
