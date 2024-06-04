using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AvionesBackNet.Models;
using Microsoft.AspNetCore.Mvc;
using project.utils.catalogues;
using Swashbuckle.AspNetCore.Annotations;

namespace AvionesBackNet.Modules.Catalogues.Controllers
{
    [ApiController]
    [Route("MARCA_AV")]
    [SwaggerTag("Catalogo de marcas de aviones")]
    public class marcaAvionController : cataloguesController
    {
        public marcaAvionController(AvionesContext context, IMapper mapper) : base(context, mapper)
        {
            codCatalogue = "MARCA_AV";
        }
    }
}