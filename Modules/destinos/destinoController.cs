
using AutoMapper;
using AvionesBackNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project.utils;

namespace AvionesBackNet.Modules.destinos
{
    [ApiController]
    [Route("destinoAutorizados")]

    public class destinoController : controllerCommons<AerolineaAeropuerto, destinoCreationDto, destinoDto, destinoQueryDto, object, long>
    {
        public destinoController(AvionesContext context, IMapper mapper) : base(context, mapper)
        {
        }
        protected override Task<IQueryable<AerolineaAeropuerto>> modifyGet(IQueryable<AerolineaAeropuerto> query, destinoQueryDto queryParams)
        {
            query = query.Include(x => x.Aeropuerto).ThenInclude(x => x.Pais);
            return base.modifyGet(query, queryParams);
        }

        [HttpPost("modifyDestino")]
        public async Task<ActionResult<destinoDto>> modifyDestino(destinoCreationDto dto)
        {
            AerolineaAeropuerto entity = await context.AerolineaAeropuertos.FirstOrDefaultAsync(x => x.AerolineaId == dto.AerolineaId && x.AeropuertoId == dto.AeropuertoId && x.IsDestino == dto.IsDestino);
            destinoDto result;
            if (entity == null)
            {
                AerolineaAeropuerto newEntity = mapper.Map<AerolineaAeropuerto>(dto);
                context.AerolineaAeropuertos.Add(newEntity);
                await context.SaveChangesAsync();
                result = mapper.Map<destinoDto>(newEntity);

            }
            else
            {
                entity.deleteAt = null;
                await context.SaveChangesAsync();
                result = mapper.Map<destinoDto>(entity);
            }
            return Ok(result);
        }
    }
}