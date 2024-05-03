using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AvionesBackNet.Models;
using AvionesBackNet.utils;
using Microsoft.AspNetCore.Mvc;

namespace AvionesBackNet.Modules.seats
{
    [ApiController]
    [Route("[controller]")]
    public class SeatsController : controllerCommons<Asiento, asientoDtoCreation, asientoDto, object, object, ulong>
    {
        public SeatsController(AvionesContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}