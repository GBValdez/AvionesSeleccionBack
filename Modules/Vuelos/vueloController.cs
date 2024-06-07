using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AvionesBackNet.Models;
using AvionesBackNet.Modules.Vuelos.dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project.utils;
using project.utils.dto;

namespace AvionesBackNet.Modules.Vuelos
{
    [ApiController]
    [Route("[controller]")]
    public class VueloController : controllerCommons<Vuelo, vueloDtoCreation, vueloDto, vueloQueryDto, object, long>
    {
        public VueloController(AvionesContext context, IMapper mapper) : base(context, mapper)
        {
        }
        protected override async Task<IQueryable<Vuelo>> modifyGet(IQueryable<Vuelo> query, vueloQueryDto queryParams)
        {
            query = query
                .Include(v => v.AeropuertoDestino)
                .ThenInclude(a => a.Pais)
                .Include(v => v.AeropuertoOrigen)
                .ThenInclude(a => a.Pais)
                .Include(v => v.Avion)
                .ThenInclude(a => a.Modelo)
                .Include(v => v.VueloClases)
                .ThenInclude(vc => vc.Clase);

            return query;
        }
        protected override async Task modifyPut(Vuelo entity, vueloDtoCreation dtoNew, object queryParams)
        {
            List<VueloClase> vueloClases = await context.VueloClases.Where(vc => vc.VueloId == entity.Id).ToListAsync();
            context.VueloClases.RemoveRange(vueloClases);
            await context.SaveChangesAsync();

        }
        protected override async Task<errorMessageDto> validPost(vueloDtoCreation dtoNew, object queryParams)
        {
            if (DateTime.Now > dtoNew.FechaSalida)
            {
                return new errorMessageDto("No se puede crear un vuelo con fecha de salida anterior a la actual");
            }

            if (dtoNew.FechaSalida > dtoNew.FechaLlegada)
            {
                return new errorMessageDto("La fecha de salida no puede ser mayor a la fecha de llegada");
            }
            if (dtoNew.AeropuertoDestinoId == dtoNew.AeropuertoOrigenId)
            {
                return new errorMessageDto("El aeropuerto de destino no puede ser el mismo que el de origen");
            }

            Avione avione = await context.Aviones.Where(a => a.Id == dtoNew.AvionId && a.deleteAt == null).FirstOrDefaultAsync();
            if (avione == null)
            {
                return new errorMessageDto("El avion no existe");
            }
            bool avionEnUso = await context.Vuelos.AnyAsync(v => v.AvionId == dtoNew.AvionId && v.FechaLlegada > dtoNew.FechaSalida && v.FechaSalida < dtoNew.FechaLlegada && v.deleteAt == null);
            if (avionEnUso)
            {
                return new errorMessageDto("El avion ya esta en uso en ese horario");
            }
            return null;

        }
        protected override async Task<errorMessageDto> validPut(vueloDtoCreation dtoNew, Vuelo entity, object queryParams)
        {
            if (DateTime.Now > entity.FechaSalida)
            {
                return new errorMessageDto("No se puede modificar un vuelo que ya ha salido");
            }
            if (dtoNew.FechaSalida > dtoNew.FechaLlegada)
            {
                return new errorMessageDto("La fecha de salida no puede ser mayor a la fecha de llegada");
            }
            if (dtoNew.AeropuertoDestinoId == dtoNew.AeropuertoOrigenId)
            {
                return new errorMessageDto("El aeropuerto de destino no puede ser el mismo que el de origen");
            }

            Avione avione = await context.Aviones.Where(a => a.Id == dtoNew.AvionId && a.deleteAt == null).FirstOrDefaultAsync();
            if (avione == null)
            {
                return new errorMessageDto("El avion no existe");
            }
            bool avionEnUso = await context.Vuelos.AnyAsync(v => v.AvionId == dtoNew.AvionId && v.FechaLlegada > dtoNew.FechaSalida && v.FechaSalida < dtoNew.FechaLlegada && v.Id != entity.Id && v.deleteAt == null);
            if (avionEnUso)
            {
                return new errorMessageDto("El avion ya esta en uso en ese horario");
            }
            return null;
        }
    }
}