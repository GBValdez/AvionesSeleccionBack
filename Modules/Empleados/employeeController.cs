using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AvionesBackNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project.utils;

namespace AvionesBackNet.Modules.Empleados
{

    [ApiController]
    [Route("employee")]
    public class employeeController : controllerCommons<Empleado, employeeCreationDto, employeeDto, object, object, long>
    {
        public employeeController(AvionesContext context, IMapper mapper) : base(context, mapper)
        {
        }
        protected override async Task<IQueryable<Empleado>> modifyGet(IQueryable<Empleado> query, object queryParams)
        {
            return query.Include(e => e.Pais).Include(e => e.Puesto).Include(e => e.Tripulacion).Include(e => e.User);
        }
    }
}