using AutoMapper;
using AvionesBackNet.Models;
using Microsoft.AspNetCore.Mvc;
using project.utils;
using project.utils.catalogues;
using Swashbuckle.AspNetCore.Annotations;

namespace AvionesBackNet.Modules.Catalogues.Controllers
{
    [ApiController]
    [Route("CAA")]
    [SwaggerTag("Catalogo de clases de los asientos")]

    public class clasesSeatsController : cataloguesController
    {
        public clasesSeatsController(AvionesContext context, IMapper mapper) : base(context, mapper)
        {
            codCatalogue = "CAA";

        }
    }
}
