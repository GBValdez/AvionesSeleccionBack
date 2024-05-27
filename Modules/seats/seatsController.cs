using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AvionesBackNet.Models;
using AvionesBackNet.utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AvionesBackNet.Modules.seats
{
    [ApiController]
    [Route("[controller]")]
    public class SeatsController : controllerCommons<Asiento, asientoDtoCreation, asientoDto, object, object, long>
    {
        public SeatsController(AvionesContext context, IMapper mapper) : base(context, mapper)
        {
        }
        protected override Task<IQueryable<Asiento>> modifyGet(IQueryable<Asiento> query, object queryParams)
        {
            query = query.Include(db => db.Clase);
            return base.modifyGet(query, queryParams);
        }

        [HttpPost("saveSeats/{idPlane}")]
        public async Task<ActionResult> saveSeats(long idPlane, seatPlaneDto seats)
        {
            Avione? plane = await context.Aviones.FindAsync(idPlane);
            if (plane == null)
            {
                return NotFound();
            }
            List<Asiento> asientos = mapper.Map<List<Asiento>>(seats.asientos);
            plane.Asientos = asientos;
            plane.TamAsientoPorc = seats.sizeSeat;
            await context.SaveChangesAsync();
            return Ok();
        }


    }
}