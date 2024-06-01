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
    [Route("[controller]")]
    public class estadoBoleController : cataloguesController
    {
        public estadoBoleController(AvionesContext context, IMapper mapper) : base(context, mapper)
        {
            codCatalogue = "EB";
        }
    }
}