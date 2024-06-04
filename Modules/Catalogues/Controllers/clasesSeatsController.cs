using AutoMapper;
using AvionesBackNet.Models;
using Microsoft.AspNetCore.Mvc;
using project.utils;
using project.utils.catalogues;

namespace AvionesBackNet.Modules.Catalogues.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class clasesSeatsController : cataloguesController
    {
        public clasesSeatsController(AvionesContext context, IMapper mapper) : base(context, mapper)
        {
            codCatalogue = "CAA";

        }
    }
}
