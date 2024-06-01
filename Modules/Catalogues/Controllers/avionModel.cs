using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AvionesBackNet.Models;
using AvionesBackNet.Modules.Categories;
using Microsoft.AspNetCore.Mvc;

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