using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AvionesBackNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project.utils;

namespace AvionesBackNet.Modules.Aeropuertos
{
    [ApiController]
    [Route("[controller]")]
    public class AeropuertoController : controllerCommons<Aeropuerto, AeropuertoDtoCreation, AeropuertoDto, object, object, long>
    {
        public AeropuertoController(AvionesContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override async Task<IQueryable<Aeropuerto>> modifyGet(IQueryable<Aeropuerto> query, object queryParams)
        {
            query = query.Include(a => a.Pais).Include(a => a.ZonaHoraria);
            return query;
        }
    }
}