using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AvionesBackNet.Models;
using AvionesBackNet.Modules.Vuelos.dto;
using AvionesBackNet.utils.dto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project.utils;
using project.utils.dto;

namespace AvionesBackNet.Modules.airline
{
    [ApiController]
    [Route("airline")]
    public class AirlineController : controllerCommons<Aerolinea, airlineCreationDto, aerolineaDto, object, object, long>
    {
        public AirlineController(AvionesContext context, IMapper mapper) : base(context, mapper)
        {
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMINISTRATOR")]
        public override Task<ActionResult<resPag<aerolineaDto>>> get([FromQuery] pagQueryDto data, [FromQuery] object queryParams)
        {
            return base.get(data, queryParams);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMINISTRATOR")]
        public override Task<ActionResult<aerolineaDto>> post(airlineCreationDto newRegister, [FromQuery] object queryParams)
        {
            return base.post(newRegister, queryParams);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMINISTRATOR")]
        public override Task<ActionResult> put(airlineCreationDto entityCurrent, [FromRoute] long id, [FromQuery] object queryCreation)
        {
            return base.put(entityCurrent, id, queryCreation);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMINISTRATOR")]
        public override Task<ActionResult> delete(long id)
        {
            return base.delete(id);
        }
        protected override Task<IQueryable<Aerolinea>> modifyGet(IQueryable<Aerolinea> query, object queryParams)
        {
            query = query.Include(db => db.Pais);
            return base.modifyGet(query, queryParams);
        }
    }
}