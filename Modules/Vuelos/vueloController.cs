using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AvionesBackNet.Models;
using AvionesBackNet.Modules.airline;
using AvionesBackNet.Modules.seats;
using AvionesBackNet.Modules.Vuelos.dto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
        aerolineaSvc aerolineaSvc;
        public VueloController(AvionesContext context, IMapper mapper, aerolineaSvc aerolineaSvc) : base(context, mapper)
        {
            this.aerolineaSvc = aerolineaSvc;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public override Task<ActionResult<resPag<vueloDto>>> get([FromQuery] int pageSize, [FromQuery] int pageNumber, [FromQuery] vueloQueryDto queryParams, [FromQuery] bool? all = false)
        {
            return base.get(pageSize, pageNumber, queryParams, all);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMINISTRATOR,ADMINISTRATOR_AIRLINE")]
        public override Task<ActionResult<vueloDto>> post(vueloDtoCreation newRegister, [FromQuery] object queryParams)
        {
            return base.post(newRegister, queryParams);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMINISTRATOR,ADMINISTRATOR_AIRLINE")]
        public override Task<ActionResult> put(vueloDtoCreation entityCurrent, [FromRoute] long id, [FromQuery] object queryCreation)
        {
            return base.put(entityCurrent, id, queryCreation);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMINISTRATOR,ADMINISTRATOR_AIRLINE")]
        public override Task<ActionResult> delete(long id)
        {
            return base.delete(id);
        }
        protected override async Task<IQueryable<Vuelo>> modifyGet(IQueryable<Vuelo> query, vueloQueryDto queryParams)
        {
            aerolineaAdminValidDto valid = await aerolineaSvc.getAirlineId(queryParams.AerolineaId);

            query = query
                .Include(v => v.AeropuertoDestino)
                .ThenInclude(a => a.Pais)
                .Include(v => v.AeropuertoOrigen)
                .ThenInclude(a => a.Pais)
                .Include(v => v.Avion)
                    .ThenInclude(a => a.Modelo)
                .Include(v => v.Avion)
                    .ThenInclude(a => a.Aerolinea)
                .Include(v => v.VueloClases)
                .ThenInclude(vc => vc.Clase);

            if (valid.aerolineaId != null)
                query = query.Where(e => e.Avion.AerolineaId == valid.aerolineaId);

            return query;
        }
        protected override async Task modifyPut(Vuelo entity, vueloDtoCreation dtoNew, object queryParams)
        {
            List<VueloClase> vueloClases = await context.VueloClases.Where(vc => vc.VueloId == entity.Id).ToListAsync();
            context.VueloClases.RemoveRange(vueloClases);
            await context.SaveChangesAsync();

        }

        protected async Task<errorMessageDto> validBasic(vueloDtoCreation dtoNew, object queryParams)
        {
            if (dtoNew.FechaSalida < DateTime.Now)
            {
                return new errorMessageDto("La fecha de salida no puede ser anterior a la actual");
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

            bool hasSeats = await context.Asientos.AnyAsync(a => a.AvionId == dtoNew.AvionId && a.deleteAt == null);
            if (!hasSeats)
                return new errorMessageDto("El avion no tiene asientos");

            bool avionEnUso = await context.Vuelos.AnyAsync(v => v.AvionId == dtoNew.AvionId && v.FechaLlegada > dtoNew.FechaSalida && v.FechaSalida < dtoNew.FechaLlegada && v.deleteAt == null);
            if (avionEnUso)
            {
                return new errorMessageDto("El avion ya esta en uso en ese horario");
            }

            return null;
        }
        protected override async Task<errorMessageDto> validPost(vueloDtoCreation dtoNew, object queryParams)
        {
            errorMessageDto basic = await validBasic(dtoNew, queryParams);
            if (basic != null)
                return basic;
            return null;
        }
        protected override async Task<errorMessageDto> validPut(vueloDtoCreation dtoNew, Vuelo entity, object queryParams)
        {
            errorMessageDto basic = await validBasic(dtoNew, queryParams);
            if (basic != null)
                return basic;
            if (context.Boletos.Any(b => b.VueloId == entity.Id && b.deleteAt == null && b.EstadoBoletoId == 92))
            {
                return new errorMessageDto("No se puede modificar un vuelo con boletos vendidos");
            }

            return null;
        }

        protected async override Task<errorMessageDto> validDelete(Vuelo entity)
        {
            if (DateTime.Now > entity.FechaSalida)
            {
                return new errorMessageDto("No se puede eliminar un vuelo que ya ha salido");
            }
            if (context.Boletos.Any(b => b.VueloId == entity.Id && b.deleteAt == null && b.EstadoBoletoId == 92))
            {
                return new errorMessageDto("No se puede eliminar un vuelo con boletos vendidos");
            }
            return null;
        }

        [HttpGet("getMyFlies")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "userNormal")]
        public async Task<ActionResult<List<vueloDto>>> getMyFlies()
        {
            long idClient = long.Parse(User.Claims.FirstOrDefault(c => c.Type == "clienteId")?.Value);
            List<Vuelo> vuelos = await context.Vuelos.Where(v => v.Boletos.Any(b => b.ClienteId == idClient && b.deleteAt == null) && v.deleteAt == null)
            .Include(v => v.AeropuertoDestino)
            .ThenInclude(v => v.Pais)
            .Include(v => v.AeropuertoOrigen)
            .ThenInclude(v => v.Pais)
            .ToListAsync();
            List<vueloDto> vuelosDto = mapper.Map<List<vueloDto>>(vuelos);
            return vuelosDto;
        }
    }
}