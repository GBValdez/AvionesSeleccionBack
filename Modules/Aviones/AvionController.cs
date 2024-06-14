using AutoMapper;
using AvionesBackNet.Models;
using AvionesBackNet.Modules.airline;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project.utils;
using project.utils.dto;

namespace AvionesBackNet.Modules.Aviones
{
    [ApiController]
    [Route("[controller]")]
    public class AvionController : controllerCommons<Avione, AvionCreationDto, AvionDto, AvionQueryDto, object, long>
    {
        private aerolineaSvc aerolineaSvc;

        public AvionController(AvionesContext context, IMapper mapper, aerolineaSvc aerolineaSvc) : base(context, mapper)
        {
            this.aerolineaSvc = aerolineaSvc;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMINISTRATOR")]

        public override Task<ActionResult<resPag<AvionDto>>> get([FromQuery] int pageSize, [FromQuery] int pageNumber, [FromQuery] AvionQueryDto queryParams, [FromQuery] bool? all = false)
        {
            return base.get(pageSize, pageNumber, queryParams, all);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMINISTRATOR,ADMINISTRATOR_AIRLINE")]
        public override Task<ActionResult<AvionDto>> post(AvionCreationDto newRegister, [FromQuery] object queryParams)
        {
            return base.post(newRegister, queryParams);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMINISTRATOR,ADMINISTRATOR_AIRLINE")]
        public override Task<ActionResult> put(AvionCreationDto entityCurrent, [FromRoute] long id, [FromQuery] object queryCreation)
        {
            return base.put(entityCurrent, id, queryCreation);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMINISTRATOR,ADMINISTRATOR_AIRLINE")]
        public override Task<ActionResult> delete(long id)
        {
            return base.delete(id);
        }

        protected override async Task<IQueryable<Avione>> modifyGet(IQueryable<Avione> query, AvionQueryDto queryParams)
        {
            aerolineaAdminValidDto valid = await aerolineaSvc.getAirlineId(queryParams.AerolineaId);
            if (valid.aerlonieaId != null)
                query = query.Where(e => e.AerolineaId == valid.aerlonieaId);
            query = query.Include(e => e.Modelo).Include(e => e.Marca).Include(e => e.TipoAvion).Include(e => e.Estado).Include(e => e.Aerolinea).Include(e => e.Tripulaciones);
            return query;
        }

        protected override async Task<errorMessageDto> validPost(AvionCreationDto dtoNew, object queryParams)
        {
            aerolineaAdminValidDto valid = await aerolineaSvc.getAirlineId(dtoNew.AerolineaId);
            if (valid.error != null)
                return valid.error;
            dtoNew.AerolineaId = valid.aerlonieaId;
            return null;
        }

        protected override Task<errorMessageDto> validPut(AvionCreationDto dtoNew, Avione entity, object queryParams)
        {
            dtoNew.AerolineaId = entity.AerolineaId;
            return null;
        }
        protected override async Task modifyPost(Avione entity, object queryParams)
        {
            entity.EstadoId = 87;
        }
        protected override async Task finallyPost(Avione entity, AvionCreationDto dtoCreation, object queryParams)
        {
            Tripulacione tripulacione = await context.Tripulaciones.FirstOrDefaultAsync(t => t.Id == dtoCreation.TripulacionId);
            if (tripulacione != null)
            {
                tripulacione.AvionId = entity.Id;
                await context.SaveChangesAsync();
            }
        }
        protected override async Task finallyPut(Avione entity, AvionCreationDto dtoNew, object queryParams)
        {
            Tripulacione tripulacione = await context.Tripulaciones.FirstOrDefaultAsync(t => t.AvionId == entity.Id);
            if (tripulacione != null)
            {
                tripulacione.AvionId = null;
            }
            Tripulacione newTripulacione = await context.Tripulaciones.FirstOrDefaultAsync(t => t.Id == dtoNew.TripulacionId);
            if (newTripulacione != null)
            {
                newTripulacione.AvionId = entity.Id;
            }
            await context.SaveChangesAsync();

        }

        protected override async Task<errorMessageDto> validDelete(Avione entity)
        {
            aerolineaAdminValidDto valid = await aerolineaSvc.getAirlineId(entity.AerolineaId);
            if (valid.error != null)
                return valid.error;
            if (valid.aerlonieaId != entity.AerolineaId)
                return new errorMessageDto("No se puede eliminar un empleado de otra aerolínea");

            var vuelosPendientes = await context.Vuelos
                .FromSqlInterpolated($"SELECT * FROM Vuelos v WHERE v.AvionId = {entity.Id} AND (now() < v.FechaSalida OR now() < v.FechaLlegada) AND v.deleteAt IS NULL")
                .ToListAsync();
            if (vuelosPendientes.Any())
            {

                return new errorMessageDto("No se puede eliminar un avión con vuelos pendientes");
            }

            Tripulacione tripulacione = await context.Tripulaciones.FirstOrDefaultAsync(t => t.AvionId == entity.Id);
            if (tripulacione != null)
            {
                tripulacione.AvionId = null;
            }
            return null;

        }

    }
}