using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AvionesBackNet.Models;
using AvionesBackNet.Modules.Paises;
using Microsoft.AspNetCore.Mvc;
using project.utils;

namespace AvionesBackNet.Modules.country
{
    [ApiController]
    [Route("country")]
    public class CountryController : controllerCommons<Paise, countryCreationDto, paisDto, object, object, long>
    {
        public CountryController(AvionesContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}