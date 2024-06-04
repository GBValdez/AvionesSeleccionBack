using AutoMapper;
using AvionesBackNet.Models;
using Microsoft.AspNetCore.Mvc;
using project.utils;
using project.utils.catalogues;

namespace AvionesBackNet.Modules.Catalogues.Controllers
{
    [ApiController]
    [Route("modeloAvion")]

    public class AvionModel : cataloguesController
    {
        public AvionModel(AvionesContext context, IMapper mapper) : base(context, mapper)
        {
            codCatalogue = "MODELO_AV";
        }
    }
}