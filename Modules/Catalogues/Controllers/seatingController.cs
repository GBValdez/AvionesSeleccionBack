using AutoMapper;
using AvionesBackNet.Models;
using AvionesBackNet.Modules.Categories;
using Microsoft.AspNetCore.Mvc;

namespace AvionesBackNet.Modules.Catalogues.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class seatingController : cataloguesController
    {
        public seatingController(AvionesContext context, IMapper mapper) : base(context, mapper)
        {
            codCatalogue = "CAA";
        }
    }
}
