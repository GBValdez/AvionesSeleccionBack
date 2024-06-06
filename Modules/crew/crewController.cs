using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AvionesBackNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project.utils;

namespace AvionesBackNet.Modules.crew
{

    [ApiController]
    [Route("crew")]

    public class crewController : controllerCommons<Tripulacione, crewCreationDto, crewDto, object, object, long>
    {
        public crewController(AvionesContext context, IMapper mapper) : base(context, mapper)
        {
        }
        protected override Task<IQueryable<Tripulacione>> modifyGet(IQueryable<Tripulacione> query, object queryParams)
        {
            query = query.Include(db => db.Empleados);
            return base.modifyGet(query, queryParams);
        }

    }
}