using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AvionesBackNet.Models;
using AvionesBackNet.users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project.users;
using project.users.dto;
using project.utils;
using project.utils.dto;

namespace AvionesBackNet.Modules.Empleados
{

    [ApiController]
    [Route("employee")]
    public class employeeController : controllerCommons<Empleado, employeeCreationDto, employeeDto, employeeQuery, object, long>
    {
        protected userSvc userSvc;
        public employeeController(AvionesContext context, IMapper mapper, userSvc userSvc) : base(context, mapper)
        {
            this.userSvc = userSvc;
        }
        protected override async Task<IQueryable<Empleado>> modifyGet(IQueryable<Empleado> query, employeeQuery queryParams)
        {
            if (queryParams.withoutTripulation != null)
                if (queryParams.withoutTripulation == true)
                    query = query.Where(e => e.TripulacionId == null);
            return query.Include(e => e.Pais).Include(e => e.Puesto).Include(e => e.Tripulacion).Include(e => e.User);
        }

        protected override async Task<errorMessageDto> validPost(employeeCreationDto dtoNew, object queryParams)
        {
            userCreationDto userCreation = new userCreationDto
            {
                email = dtoNew.Correo,
                password = Guid.NewGuid().ToString() + "C0NTR@S3N@",
                userName = dtoNew.UserId
            };
            errorMessageDto registerResult = await userSvc.register(userCreation, new List<string> { "EMPLOYEE" });
            if (registerResult != null)
                return registerResult;

            userEntity user = await context.Users.FirstOrDefaultAsync(u => u.UserName == dtoNew.UserId);
            dtoNew.UserId = user.Id;

            return null;

        }
        protected override Task modifyPost(Empleado entity, object queryParams)
        {
            entity.AerolineaId = 1;
            entity.TripulacionId = null;
            return base.modifyPost(entity, queryParams);
        }
        protected override Task modifyPut(Empleado entity, employeeCreationDto dtoNew, object queryParams)
        {
            dtoNew.UserId = entity.UserId;
            return base.modifyPut(entity, dtoNew, queryParams);
        }

        [HttpGet("allAndCrew/{id}/{idPuesto}")]
        public async Task<ActionResult<List<employeeDto>>> getAllAndCrew(
            [FromRoute] long id,
            [FromRoute] long idPuesto
            )
        {
            List<Empleado> empleados = await context.Empleados.Where(e => (e.TripulacionId == null || e.TripulacionId == id) && e.deleteAt == null && e.PuestoId == idPuesto).ToListAsync();
            List<employeeDto> empleadosDto = mapper.Map<List<employeeDto>>(empleados);
            return empleadosDto;
        }

    }
}