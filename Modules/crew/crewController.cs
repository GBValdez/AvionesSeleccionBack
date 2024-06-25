using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AvionesBackNet.Models;
using AvionesBackNet.Modules.airline;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project.users;
using project.utils;
using project.utils.dto;

namespace AvionesBackNet.Modules.crew
{

    [ApiController]
    [Route("crew")]

    public class crewController : controllerCommons<Tripulacione, crewPersonalDto, crewDto, crewQuerryDto, object, long>
    {
        private aerolineaSvc aerolineaSvc;

        public crewController(AvionesContext context, IMapper mapper, aerolineaSvc aerolineaSvc) : base(context, mapper)
        {
            this.aerolineaSvc = aerolineaSvc;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMINISTRATOR,ADMINISTRATOR_AIRLINE")]
        public override Task<ActionResult<resPag<crewDto>>> get([FromQuery] int pageSize, [FromQuery] int pageNumber, [FromQuery] crewQuerryDto queryParams, [FromQuery] bool? all = false)
        {
            return base.get(pageSize, pageNumber, queryParams, all);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMINISTRATOR,ADMINISTRATOR_AIRLINE")]
        public override async Task<ActionResult<crewDto>> post(crewPersonalDto newRegister, [FromQuery] object queryParams)
        {
            return BadRequest(new errorMessageDto("Esta api esta bloqueada"));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMINISTRATOR,ADMINISTRATOR_AIRLINE")]
        public override async Task<ActionResult> put(crewPersonalDto entityCurrent, [FromRoute] long id, [FromQuery] object queryCreation)
        {
            return BadRequest(new errorMessageDto("Esta api esta bloqueada"));
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMINISTRATOR,ADMINISTRATOR_AIRLINE")]
        public override Task<ActionResult> delete(long id)
        {
            return base.delete(id);
        }
        protected override async Task<IQueryable<Tripulacione>> modifyGet(IQueryable<Tripulacione> query, crewQuerryDto queryParams)
        {
            aerolineaAdminValidDto valid = await aerolineaSvc.getAirlineId(queryParams.AerolineaId);
            if (valid.aerolineaId != null)
                query = query.Where(e => e.AerolineaId == valid.aerolineaId);
            query = query.Include(db => db.Empleados).ThenInclude(db => db.Puesto);
            return query;
        }


        [HttpPost("createCrew")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMINISTRATOR,ADMINISTRATOR_AIRLINE")]
        public async Task<ActionResult> createCrew(crewPersonalDto crew)
        {
            aerolineaAdminValidDto valid = await aerolineaSvc.getAirlineId(crew.AerolineaId);
            if (valid.error != null)
                return BadRequest(valid.error);
            Tripulacione tripulacione = mapper.Map<Tripulacione>(crew);
            tripulacione.AerolineaId = (long)valid.aerolineaId;
            context.Tripulaciones.Add(tripulacione);
            errorMessageDto error = await saveCrew(crew, tripulacione);
            if (error != null)
            {
                return BadRequest(error);
            }

            return Ok();
        }

        [HttpPut("updateCrew/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMINISTRATOR,ADMINISTRATOR_AIRLINE")]
        public async Task<ActionResult> updateCrew(long id, crewPersonalDto crew)
        {
            Tripulacione tripulacione = await context.Tripulaciones.FindAsync(id);
            if (tripulacione == null)
            {
                return NotFound();
            }
            crew.AerolineaId = tripulacione.AerolineaId;
            mapper.Map(crew, tripulacione);
            List<Empleado> empleados = await context.Empleados.Where(e => e.TripulacionId == id).ToListAsync();
            foreach (Empleado empleado in empleados)
            {
                empleado.TripulacionId = null;
            }

            await context.SaveChangesAsync();
            errorMessageDto error = await saveCrew(crew, tripulacione);
            if (error != null)
            {
                return BadRequest(error);
            }
            return Ok();
        }

        protected override async Task<errorMessageDto> validDelete(Tripulacione entity)
        {
            aerolineaAdminValidDto valid = await aerolineaSvc.getAirlineId(entity.AerolineaId);
            if (valid.error != null)
                return valid.error;
            if (valid.aerolineaId != entity.AerolineaId)
                return new errorMessageDto("No se puede eliminar una tripulación de otra aerolínea");

            if (entity.AvionId != null)
            {
                return new errorMessageDto("No se puede eliminar una tripulación que está asignada a un avión");
            }
            List<Empleado> empleados = await context.Empleados.Where(e => e.TripulacionId == entity.Id).ToListAsync();
            foreach (Empleado empleado in empleados)
            {
                empleado.TripulacionId = null;
            }
            await context.SaveChangesAsync();
            return null;
        }

        private async Task<errorMessageDto> saveCrew(crewPersonalDto crew, Tripulacione tripulacione)
        {
            await context.SaveChangesAsync();
            List<long> employes = new List<long>
                {
                    crew.piloto,
                    crew.copiloto,
                    crew.ingeniero,
                    crew.azafata1,
                    crew.azafata2,
                    crew.azafata3
                };

            // Verificar si todos los empleados existen antes de hacer cualquier cambio
            foreach (long id in employes)
            {
                if (!await context.Empleados.AnyAsync(e => e.Id == id))
                {
                    return new errorMessageDto("No se encontró el empleado con el id: " + id);
                }
            }

            // Actualizar la tripulación de los empleados
            foreach (long id in employes)
            {
                var empleado = await context.Empleados.FindAsync(id);
                if (empleado != null)
                {
                    empleado.TripulacionId = tripulacione.Id;
                }
            }
            await context.SaveChangesAsync();
            return null;
        }
        [HttpGet("allAndPlane/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMINISTRATOR,ADMINISTRATOR_AIRLINE")]
        public async Task<ActionResult<List<crewDto>>> getAllAndCrew(
            [FromRoute] long id,
            [FromQuery] crewQuerryDto queryParams
        )
        {
            aerolineaAdminValidDto valid = await aerolineaSvc.getAirlineId(queryParams.AerolineaId);
            if (valid.error != null)
                return BadRequest(valid.error);
            List<Tripulacione> tripulaciones = await context.Tripulaciones.Where(e => (e.AvionId == null || e.AvionId == id) && e.deleteAt == null && e.AerolineaId == valid.aerolineaId).ToListAsync();
            List<crewDto> crewDtoList = mapper.Map<List<crewDto>>(tripulaciones);
            return crewDtoList;
        }


    }
}