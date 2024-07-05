using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AvionesBackNet.Models;
using AvionesBackNet.Modules.Aviones;
using AvionesBackNet.Modules.Catalogues;
using AvionesBackNet.Modules.Vuelos;
using AvionesBackNet.utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project.utils;
using project.utils.dto;

namespace AvionesBackNet.Modules.seats
{
    [ApiController]
    [Route("[controller]")]
    public class SeatsController : controllerCommons<Asiento, asientoDtoCreation, asientoDto, asientoQueryDto, object, long>
    {

        public SeatsController(AvionesContext context, IMapper mapper) : base(context, mapper)
        {
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public override Task<ActionResult<resPag<asientoDto>>> get([FromQuery] int pageSize, [FromQuery] int pageNumber, [FromQuery] asientoQueryDto queryParams, [FromQuery] bool? all = false)
        {
            return base.get(pageSize, pageNumber, queryParams, all);
        }

        protected override Task<IQueryable<Asiento>> modifyGet(IQueryable<Asiento> query, asientoQueryDto queryParams)
        {
            query = query.Include(db => db.Clase);
            return base.modifyGet(query, queryParams);
        }

        [HttpGet("canEditSeats/{idPlane}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMINISTRATOR,ADMINISTRATOR_AIRLINE")]
        public async Task<ActionResult> canEditSeats(long idPlane)
        {
            Avione? plane = await context.Aviones.FirstOrDefaultAsync(p => p.Id == idPlane && p.deleteAt == null);
            if (plane == null)
            {
                return NotFound();
            }
            if (await context.Vuelos.AnyAsync(f => f.AvionId == idPlane && f.deleteAt == null && f.FechaLlegada > DateTime.UtcNow))
            {
                return BadRequest(new errorMessageDto("No se pueden modificar los asientos de un avión con vuelos pendientes"));
            }
            return Ok();
        }

        [HttpPost("saveSeats/{idPlane}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMINISTRATOR,ADMINISTRATOR_AIRLINE")]
        public async Task<ActionResult> saveSeats(long idPlane, seatPlaneDto seats)
        {
            Avione? plane = await context.Aviones.FirstOrDefaultAsync(p => p.Id == idPlane && p.deleteAt == null);
            if (plane == null)
            {
                return NotFound();
            }
            if (await context.Vuelos.AnyAsync(f => f.AvionId == idPlane && f.deleteAt == null && f.FechaLlegada > DateTime.UtcNow))
            {
                return BadRequest(new errorMessageDto("No se pueden modificar los asientos de un avión con vuelos pendientes"));
            }

            List<Asiento> seatsListDB = await context.Asientos.Where(s => s.AvionId == idPlane).ToListAsync();

            if (seatsListDB.Count >= seats.asientos.Count)
            {
                for (int i = 0; i < seats.asientos.Count; i++)
                {
                    mapper.Map(seats.asientos[i], seatsListDB[i]);
                    seatsListDB[i].AvionId = idPlane;
                    seatsListDB[i].deleteAt = null;
                }
                for (int i = seats.asientos.Count; i < seatsListDB.Count; i++)
                {
                    if (seatsListDB[i].deleteAt == null)
                        seatsListDB[i].deleteAt = DateTime.UtcNow;
                }
            }
            else
            {
                for (int i = 0; i < seatsListDB.Count; i++)
                {
                    mapper.Map(seats.asientos[i], seatsListDB[i]);
                    seatsListDB[i].deleteAt = null;
                    seatsListDB[i].AvionId = idPlane;
                }
                for (int i = seatsListDB.Count; i < seats.asientos.Count; i++)
                {
                    Asiento newSeat = mapper.Map<Asiento>(seats.asientos[i]);
                    newSeat.AvionId = idPlane;
                    context.Asientos.Add(newSeat);
                }
            }
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("getSeatsOfFly/{idFly}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<ActionResult<avionWithSeatsDto>> getSeatsOfFly(long idFly)
        {
            string idClient = User.Claims.FirstOrDefault(c => c.Type == "clienteId")?.Value;
            if (idClient == null)
            {
                return BadRequest(new errorMessageDto("El usuario no esta autenticado como cliente"));
            }
            long idClientL = long.Parse(idClient);
            Vuelo? fly = await context.Vuelos.Where(v => v.Id == idFly && v.deleteAt == null)
            .Include(x => x.Avion)
            .FirstOrDefaultAsync();
            if (fly == null)
            {
                return null;
            }
            List<Asiento> asientos = await context.Asientos.Where(a => a.AvionId == fly.AvionId && a.deleteAt == null).Include(x => x.Clase).ToListAsync();
            List<asientoDto> asientosDto = mapper.Map<List<asientoDto>>(asientos);
            List<Boleto> boletos = await context.Boletos.Where(b => b.VueloId == idFly && b.deleteAt == null).Include(a => a.EstadoBoleto).ToListAsync();
            List<boletoDto> boletoDtos = mapper.Map<List<boletoDto>>(boletos);
            boletoDtos.ForEach(b => { b.ClienteId = b.ClienteId.Equals(idClientL) ? idClientL : -1; });

            List<VueloClase> vueloClaseList = await context.VueloClases.Where(v => v.VueloId == idFly && v.deleteAt == null).Include(x => x.Clase).ToListAsync();
            avionWithSeatsDto avionWithSeatsDto = new avionWithSeatsDto();
            avionWithSeatsDto.asientoDtos = asientosDto;
            fly.Avion.Asientos = null;
            fly.Avion.Vuelos = null;
            avionWithSeatsDto.avion = mapper.Map<AvionDto>(fly.Avion);
            avionWithSeatsDto.classList = mapper.Map<List<vueloClaseDto>>(vueloClaseList);
            avionWithSeatsDto.boletos = boletoDtos;
            return avionWithSeatsDto;
        }


    }
}