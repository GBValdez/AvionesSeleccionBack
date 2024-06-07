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

namespace AvionesBackNet.Modules.Vuelos
{
    [ApiController]
    [Route("[controller]")]
    public class VueloController : controllerCommons<Vuelo, vueloDtoCreation, vueloDto, vueloQueryDto, object, long>
    {
        public VueloController(AvionesContext context, IMapper mapper) : base(context, mapper)
        {
        }
        protected override async Task<IQueryable<Vuelo>> modifyGet(IQueryable<Vuelo> query, vueloQueryDto queryParams)
        {
            query = query
                .Include(v => v.AeropuertoDestino)
                .ThenInclude(a => a.Pais)
                .Include(v => v.AeropuertoOrigen)
                .ThenInclude(a => a.Pais)
                .Include(v => v.Avion)
                .ThenInclude(a => a.Modelo)
                .Include(v => v.VueloClases)
                .ThenInclude(vc => vc.Clase);

            return query;
        }
        protected override async Task modifyPut(Vuelo entity, vueloDtoCreation dtoNew, object queryParams)
        {
            List<VueloClase> vueloClases = await context.VueloClases.Where(vc => vc.VueloId == entity.Id).ToListAsync();
            context.VueloClases.RemoveRange(vueloClases);
            await context.SaveChangesAsync();

        }
    }
}