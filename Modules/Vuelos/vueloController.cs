using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AvionesBackNet.Models;
using AvionesBackNet.utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AvionesBackNet.Modules.Vuelos
{
    [ApiController]
    [Route("[controller]")]
    public class VueloController : controllerCommons<Vuelo, vueloDtoCreation, vueloDto, object, object, long>
    {
        public VueloController(AvionesContext context, IMapper mapper) : base(context, mapper)
        {
        }
        protected override async Task<IQueryable<Vuelo>> modifyGet(IQueryable<Vuelo> query, object queryParams)
        {
            query = query.Include(v => v.AeropuertoDestino).Include(v => v.AeropuertoOrigen);
            return query;
        }
    }
}