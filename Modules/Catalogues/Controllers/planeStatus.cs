using AutoMapper;
using AvionesBackNet.Models;
using Microsoft.AspNetCore.Mvc;
using project.utils;
using project.utils.catalogues;
using Swashbuckle.AspNetCore.Annotations;

namespace AvionesBackNet.Modules.Catalogues.Controllers
{
    [ApiController]
    [Route("EST_AV")]
    [SwaggerTag("Catalogo de estados de aviones")]
    public class PlaneStatus : cataloguesController
    {
        public PlaneStatus(AvionesContext context, IMapper mapper) : base(context, mapper)
        {
            codCatalogue = "EST_AV";
        }
    }
}