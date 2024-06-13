using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AvionesBackNet.Models;
using AvionesBackNet.Modules.Catalogues;
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

        [HttpPost("saveSeats/{idPlane}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMINISTRATOR")]
        public async Task<ActionResult> saveSeats(long idPlane, seatPlaneDto seats)
        {
            Avione? plane = await context.Aviones.Include(p => p.Asientos).FirstOrDefaultAsync(p => p.Id == idPlane);
            if (plane == null)
            {
                return NotFound();
            }

            // Eliminar los asientos antiguos
            context.Asientos.RemoveRange(plane.Asientos);

            // Mapear y agregar los nuevos asientos
            List<Asiento> asientos = mapper.Map<List<Asiento>>(seats.asientos);
            plane.Asientos = asientos;
            plane.TamAsientoPorc = seats.sizeSeat;

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