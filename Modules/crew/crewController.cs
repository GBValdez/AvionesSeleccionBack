using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AvionesBackNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project.users;
using project.utils;
using project.utils.dto;

namespace AvionesBackNet.Modules.crew
{

    [ApiController]
    [Route("crew")]

    public class crewController : controllerCommons<Tripulacione, crewCreationDto, crewDto, object, object, long>
    {
        public crewController(AvionesContext context, IMapper mapper) : base(context, mapper)
        {
        }
        protected override Task<IQueryable<Tripulacione>> modifyGet(IQueryable<Tripulacione> query, object queryParams)
        {
            query = query.Include(db => db.Empleados).ThenInclude(db => db.Puesto);
            return base.modifyGet(query, queryParams);
        }


        [HttpPost("createCrew")]
        public async Task<ActionResult> createCrew(crewPersonalDto crew)
        {
            Tripulacione tripulacione = mapper.Map<Tripulacione>(crew);
            tripulacione.AerolineaId = 1;
            context.Tripulaciones.Add(tripulacione);
            errorMessageDto error = await saveCrew(crew, tripulacione);
            if (error != null)
            {
                return BadRequest(error);
            }

            return Ok();
        }

        [HttpPut("updateCrew/{id}")]
        public async Task<ActionResult> updateCrew(long id, crewPersonalDto crew)
        {
            Tripulacione tripulacione = await context.Tripulaciones.FindAsync(id);
            if (tripulacione == null)
            {
                return NotFound();
            }
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

    }
}