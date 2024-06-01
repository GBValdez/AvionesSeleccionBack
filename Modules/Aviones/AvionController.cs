using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AvionesBackNet.Models;
using AvionesBackNet.utils;
using Microsoft.AspNetCore.Mvc;

namespace AvionesBackNet.Modules.Aviones
{
    [ApiController]
    [Route("[controller]")]
    public class AvionController : controllerCommons<Avione, AvionCreationDto, AvionDto, AvionQueryDto, object, long>
    {
        public AvionController(AvionesContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}