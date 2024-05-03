using AutoMapper;
using AvionesBackNet.Models;
using AvionesBackNet.Modules.Categories;
using Microsoft.AspNetCore.Mvc;

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

        protected override Task<IQueryable<Catalogo>> modifyGet(IQueryable<Catalogo> query, object queryParams)
        {
            return base.modifyGet(query, queryParams);
        }
    }
}
