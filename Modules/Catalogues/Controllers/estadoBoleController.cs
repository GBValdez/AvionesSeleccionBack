using AutoMapper;
using AvionesBackNet.Models;
using Microsoft.AspNetCore.Mvc;
using project.utils;
using project.utils.catalogues;
using Swashbuckle.AspNetCore.Annotations;

namespace AvionesBackNet.Modules.Catalogues.Controllers
{
    [ApiController]
    [Route("EB")]
    [SwaggerTag("Catalogo de estados de boletos")]
    public class estadoBoleController : cataloguesController
    {
        public estadoBoleController(AvionesContext context, IMapper mapper) : base(context, mapper)
        {
            codCatalogue = "EB";

        }
    }
}