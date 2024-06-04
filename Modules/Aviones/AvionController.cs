using AutoMapper;
using AvionesBackNet.Models;
using Microsoft.AspNetCore.Mvc;
using project.utils;

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