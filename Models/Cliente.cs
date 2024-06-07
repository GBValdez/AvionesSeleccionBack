using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using project.users;
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
    public string UserId { get; set; }


    public long CodigoTelefono { get; set; }

    public long CodigoTelefonoEmergencia { get; set; }
    public virtual ICollection<Boleto> Boletos { get; set; } = new List<Boleto>();
    [ForeignKey("CodigoTelefonoEmergencia")]

    public virtual Paise CodigoTelefonoEmergenciaObj { get; set; } = null!;

    [ForeignKey("CodigoTelefono")]
    public virtual Paise CodigoTelefonoObj { get; set; } = null!;
    [ForeignKey("PaisId")]
    public virtual Paise Pais { get; set; } = null!;

    [ForeignKey("UserId")]
    public userEntity User { get; set; } = null!;
}
