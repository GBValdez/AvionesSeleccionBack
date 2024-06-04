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
    [Route("TIP_AV")]
    public class tipoAvionController : cataloguesController
    {
        public tipoAvionController(AvionesContext context, IMapper mapper) : base(context, mapper)
        {
            codCatalogue = "TIP_AV";
        }
    }
}