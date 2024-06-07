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



        public override Task<ActionResult<resPag<paisDto>>> get([FromQuery] int pageSize, [FromQuery] int pageNumber, [FromQuery] object queryParams, [FromQuery] bool? all = false)
        {
            return base.get(pageSize, pageNumber, queryParams, all);
        }
    }
}