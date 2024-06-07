using AutoMapper;
using AvionesBackNet.Models;
using AvionesBackNet.utils.Catalogues;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using project.utils;
using project.utils.catalogues;
using project.utils.catalogues.dto;
using project.utils.dto;
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
