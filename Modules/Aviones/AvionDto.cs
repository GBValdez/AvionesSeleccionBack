using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvionesBackNet.Models;

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
        public virtual Aerolinea Aerolinea { get; set; } = null!;

        public virtual Catalogo Estado { get; set; } = null!;

        public virtual Catalogo Marca { get; set; } = null!;

        public virtual Catalogo Modelo { get; set; } = null!;

        public virtual Catalogo TipoAvion { get; set; } = null!;
        public virtual ICollection<Vuelo> Vuelos { get; set; } = new List<Vuelo>();
        public virtual ICollection<Asiento> Asientos { get; set; } = new List<Asiento>();
    }
}