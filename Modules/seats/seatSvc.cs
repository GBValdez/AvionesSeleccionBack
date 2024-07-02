using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AvionesBackNet.Models;
using AvionesBackNet.Modules.Aviones;
using AvionesBackNet.Modules.Catalogues;
using AvionesBackNet.Modules.Vuelos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project.utils.catalogues.dto;

namespace AvionesBackNet.Modules.seats
{
    public class seatSvc
    {
        private AvionesContext context;
        private IMapper mapper;

        public seatSvc(AvionesContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<avionWithSeatsDto> getSeatsByFlyId(long flyId)
        {
            Vuelo? fly = await context.Vuelos.Where(v => v.Id == flyId)
            .Include(x => x.Avion)
            .FirstOrDefaultAsync();
            if (fly == null)
            {

                return null;
            }
            List<Asiento> asientos = await context.Asientos.Where(a => a.AvionId == fly.AvionId).Include(x => x.Clase).ToListAsync();
            List<asientoDto> asientosDto = mapper.Map<List<asientoDto>>(asientos);
            List<Boleto> boletos = await context.Boletos.Where(b => b.VueloId == flyId).Include(a => a.EstadoBoleto).ToListAsync();

            foreach (asientoDto item in asientosDto)
            {
                Boleto? boleto = boletos.Where(b => b.AsientoId == item.Id).FirstOrDefault();
                if (boleto != null)
                    item.Estado = mapper.Map<catalogueDto>(boleto.EstadoBoleto);
                else
                {
                    item.Estado = new catalogueDto();
                    item.Estado.Id = 30;
                    item.Estado.name = "LIBRE";
                }
            }

            List<VueloClase> vueloClaseList = await context.VueloClases.Where(v => v.VueloId == flyId && v.deleteAt == null).Include(x => x.Clase).ToListAsync();
            avionWithSeatsDto avionWithSeatsDto = new avionWithSeatsDto();
            avionWithSeatsDto.asientoDtos = asientosDto;
            fly.Avion.Asientos = null;
            fly.Avion.Vuelos = null;
            avionWithSeatsDto.avion = mapper.Map<AvionDto>(fly.Avion);
            avionWithSeatsDto.classList = mapper.Map<List<vueloClaseDto>>(vueloClaseList);
            return avionWithSeatsDto;
        }
    }
}