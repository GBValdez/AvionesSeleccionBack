using AutoMapper;
using AvionesBackNet.Models;
using Microsoft.AspNetCore.Mvc;
using project.utils;
using project.utils.catalogues;
using Swashbuckle.AspNetCore.Annotations;

namespace AvionesBackNet.Modules.Catalogues.Controllers
{
    [ApiController]
    [Route("MODELO_AV")]
    [SwaggerTag("Catalogo de modelos de aviones")]
    public class AvionModel : cataloguesController
    {
        public AvionModel(AvionesContext context, IMapper mapper) : base(context, mapper)
        {
            codCatalogue = "MODELO_AV";
        }
    }
}