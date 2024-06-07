using AutoMapper;
using AvionesBackNet.Models;
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
        public AvionController(AvionesContext context, IMapper mapper) : base(context, mapper)
        {
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMINISTRATOR")]

        public override Task<ActionResult<resPag<AvionDto>>> get([FromQuery] int pageSize, [FromQuery] int pageNumber, [FromQuery] AvionQueryDto queryParams, [FromQuery] bool? all = false)
        {
            return base.get(pageSize, pageNumber, queryParams, all);
        }
        protected override Task<IQueryable<Avione>> modifyGet(IQueryable<Avione> query, AvionQueryDto queryParams)
        {
            query = query.Include(e => e.Modelo).Include(e => e.Marca).Include(e => e.TipoAvion).Include(e => e.Estado).Include(e => e.Aerolinea).Include(e => e.Tripulaciones);
            return base.modifyGet(query, queryParams);
        }
        protected override Task modifyPost(Avione entity, object queryParams)
        {
            entity.AerolineaId = 1;
            entity.EstadoId = 87;
            return base.modifyPost(entity, queryParams);
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