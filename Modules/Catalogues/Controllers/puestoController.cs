using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AvionesBackNet.Models;
using Microsoft.AspNetCore.Mvc;
using project.utils.catalogues;

namespace AvionesBackNet.Modules.Catalogues.Controllers
{
    [ApiController]
    [Route("PUESTOS")]

    public class puestoController : cataloguesController
    {
        public puestoController(AvionesContext context, IMapper mapper) : base(context, mapper)
        {
            codCatalogue = "PUESTOS";
        }
    }

}