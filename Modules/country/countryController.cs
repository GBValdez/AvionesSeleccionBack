using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AvionesBackNet.Models;
using AvionesBackNet.Modules.Paises;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using project.utils;
using project.utils.dto;

namespace AvionesBackNet.Modules.country
{
    [ApiController]
    [Route("country")]
    public class CountryController : controllerCommons<Paise, countryCreationDto, paisDto, object, object, long>
    {
        public CountryController(AvionesContext context, IMapper mapper) : base(context, mapper)
        {
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMINISTRATOR")]
        public override Task<ActionResult<paisDto>> post(countryCreationDto newRegister, [FromQuery] object queryParams)
        {
            return base.post(newRegister, queryParams);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMINISTRATOR")]
        public override Task<ActionResult> put(countryCreationDto entityCurrent, [FromRoute] long id, [FromQuery] object queryCreation)
        {
            return base.put(entityCurrent, id, queryCreation);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMINISTRATOR")]
        public override Task<ActionResult> delete(long id)
        {
            return base.delete(id);
        }
    }
}