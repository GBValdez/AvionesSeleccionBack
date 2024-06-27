using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AvionesBackNet.Models;
using AvionesBackNet.Modules.Catalogues;
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
        private seatSvc seatSvc;

        public SeatsController(AvionesContext context, IMapper mapper, seatSvc svc) : base(context, mapper)
        {
            this.seatSvc = svc;
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
            avionWithSeatsDto asientoDtos = await seatSvc.getSeatsByFlyId(idFly);
            if (asientoDtos == null)
            {
                return NotFound();
            }
            return asientoDtos;
        }


    }
}