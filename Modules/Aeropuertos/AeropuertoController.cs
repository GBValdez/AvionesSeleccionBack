using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AvionesBackNet.Models;
using AvionesBackNet.utils.dto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project.utils;
using project.utils.dto;

namespace AvionesBackNet.Modules.Aeropuertos
{
    [ApiController]
    [Route("[controller]")]
    public class AeropuertoController : controllerCommons<Aeropuerto, AeropuertoDtoCreation, AeropuertoDto, object, object, long>
    {
        public AeropuertoController(AvionesContext context, IMapper mapper) : base(context, mapper)
        {
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public override Task<ActionResult<resPag<AeropuertoDto>>> get([FromQuery] pagQueryDto data, [FromQuery] object queryParams)
        {
            return base.get(data, queryParams);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMINISTRATOR")]
        public override Task<ActionResult<AeropuertoDto>> post(AeropuertoDtoCreation newRegister, [FromQuery] object queryParams)
        {
            return base.post(newRegister, queryParams);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMINISTRATOR")]
        public override Task<ActionResult> put(AeropuertoDtoCreation entityCurrent, [FromRoute] long id, [FromQuery] object queryCreation)
        {
            return base.put(entityCurrent, id, queryCreation);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMINISTRATOR")]
        public override Task<ActionResult> delete(long id)
        {
            return base.delete(id);
        }

        protected override async Task<IQueryable<Aeropuerto>> modifyGet(IQueryable<Aeropuerto> query, object queryParams)
        {
            query = query.Include(a => a.Pais).Include(a => a.ZonaHoraria);
            return query;
        }
    }
}