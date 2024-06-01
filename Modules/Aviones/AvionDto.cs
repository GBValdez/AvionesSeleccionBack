using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvionesBackNet.Models;
using AvionesBackNet.Modules.Catalogues;
using AvionesBackNet.Modules.seats;
using AvionesBackNet.Modules.Vuelos;
using AvionesBackNet.Modules.Vuelos.dto;

namespace AvionesBackNet.Modules.Aviones
{
    public class AvionDto
    {
        public long Id { get; set; }
        public string Year { get; set; } = null!;

        public string Serie { get; set; } = null!;

        public decimal CapacidadCarga { get; set; }

        public decimal CapacidadPasajeros { get; set; }

        public decimal CapacidadCombustible { get; set; }

        public decimal TamAsientoPorc { get; set; }
        public virtual aerolineaDto Aerolinea { get; set; } = null!;

        public virtual catalogueDto Estado { get; set; } = null!;

        public virtual catalogueDto Marca { get; set; } = null!;

        public virtual catalogueDto Modelo { get; set; } = null!;

        public virtual catalogueDto TipoAvion { get; set; } = null!;
        public virtual ICollection<vueloDto> Vuelos { get; set; }
        public virtual ICollection<asientoDto> Asientos { get; set; }
    }
}