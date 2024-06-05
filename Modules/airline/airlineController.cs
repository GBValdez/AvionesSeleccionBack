using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AvionesBackNet.Models;
using AvionesBackNet.Modules.Vuelos.dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project.utils;

namespace AvionesBackNet.Modules.airline
{
    [ApiController]
    [Route("airline")]
    public class AirlineController : controllerCommons<Aerolinea, airlineCreationDto, aerolineaDto, object, object, long>
    {
        public AirlineController(AvionesContext context, IMapper mapper) : base(context, mapper)
        {
        }
        protected override Task<IQueryable<Aerolinea>> modifyGet(IQueryable<Aerolinea> query, object queryParams)
        {
            query = query.Include(db => db.Pais);
            return base.modifyGet(query, queryParams);
        }
    }
}