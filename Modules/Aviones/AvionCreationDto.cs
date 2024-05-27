using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvionesBackNet.Modules.Aviones
{
    public class AvionCreationDto
    {
        public string Year { get; set; } = null!;

        public string Serie { get; set; } = null!;

        public decimal CapacidadCarga { get; set; }

        public decimal CapacidadPasajeros { get; set; }

        public decimal CapacidadCombustible { get; set; }

        public decimal TamAsientoPorc { get; set; }

        public long MarcaId { get; set; }

        public long AerolineaId { get; set; }

        public long ModeloId { get; set; }

        public long TipoAvionId { get; set; }

        public long EstadoId { get; set; }

    }
}