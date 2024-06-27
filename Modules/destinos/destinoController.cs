
using AutoMapper;
using AvionesBackNet.Models;
using AvionesBackNet.Modules.airline;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project.utils;
using project.utils.dto;

namespace AvionesBackNet.Modules.destinos
{
    [ApiController]
    [Route("destinoAutorizados")]

    public class destinoController : controllerCommons<AerolineaAeropuerto, destinoCreationDto, destinoDto, destinoQueryDto, object, long>
    {
        private aerolineaSvc aerolineaSvc;

        public destinoController(AvionesContext context, IMapper mapper, aerolineaSvc aerolineaSvc) : base(context, mapper)
        {
            this.aerolineaSvc = aerolineaSvc;
        }

        protected override async Task<IQueryable<AerolineaAeropuerto>> modifyGet(IQueryable<AerolineaAeropuerto> query, destinoQueryDto queryParams)
        {
            aerolineaAdminValidDto valid = await aerolineaSvc.getAirlineId(queryParams.AerolineaId);
            if (valid.aerolineaId != null)
                query = query.Where(e => e.AerolineaId == valid.aerolineaId);
            query = query.Include(x => x.Aeropuerto).ThenInclude(x => x.Pais);
            return query;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMINISTRATOR,ADMINISTRATOR_AIRLINE")]
        public override Task<ActionResult<resPag<destinoDto>>> get([FromQuery] int pageSize, [FromQuery] int pageNumber, [FromQuery] destinoQueryDto queryParams, [FromQuery] bool? all = false)
        {
            return base.get(pageSize, pageNumber, queryParams, all);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMINISTRATOR")]
        public override async Task<ActionResult<destinoDto>> post(destinoCreationDto newRegister, [FromQuery] object queryParams)
        {
            return BadRequest(new errorMessageDto("Esta api esta bloqueada"));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMINISTRATOR")]
        public override async Task<ActionResult> put(destinoCreationDto entityCurrent, [FromRoute] long id, [FromQuery] object queryCreation)
        {
            return BadRequest(new errorMessageDto("Esta api esta bloqueada"));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMINISTRATOR")]
        public override Task<ActionResult> delete(long id)
        {
            return base.delete(id);
        }

        [HttpPost("modifyDestino")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMINISTRATOR")]

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