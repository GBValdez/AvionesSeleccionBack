using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using AvionesBackNet.Models;
using AvionesBackNet.Modules.airline;
using AvionesBackNet.users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project.roles;
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
        protected UserManager<userEntity> userManager;
        private aerolineaSvc aerolineaSvc;
        public employeeController(AvionesContext context, IMapper mapper, userSvc userSvc, UserManager<userEntity> userManager, aerolineaSvc aerolineaSvc) : base(context, mapper)
        {
            this.userSvc = userSvc;
            this.userManager = userManager;
            this.aerolineaSvc = aerolineaSvc;
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMINISTRATOR,ADMINISTRATOR_AIRLINE")]
        public override Task<ActionResult<resPag<employeeDto>>> get([FromQuery] int pageSize, [FromQuery] int pageNumber, [FromQuery] employeeQuery queryParams, [FromQuery] bool? all = false)
        {
            return base.get(pageSize, pageNumber, queryParams, all);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMINISTRATOR,ADMINISTRATOR_AIRLINE")]
        public override Task<ActionResult> put(employeeCreationDto entityCurrent, [FromRoute] long id, [FromQuery] object queryCreation)
        {
            return base.put(entityCurrent, id, queryCreation);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMINISTRATOR,ADMINISTRATOR_AIRLINE")]
        public override Task<ActionResult<employeeDto>> post(employeeCreationDto newRegister, [FromQuery] object queryParams)
        {
            return base.post(newRegister, queryParams);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMINISTRATOR,ADMINISTRATOR_AIRLINE")]
        public override Task<ActionResult> delete(long id)
        {
            return base.delete(id);
        }

        protected override async Task<IQueryable<Empleado>> modifyGet(IQueryable<Empleado> query, employeeQuery queryParams)
        {
            aerolineaAdminValidDto valid = await aerolineaSvc.getAirlineId(queryParams.AerolineaId);
            if (valid.aerolineaId != null)
                query = query.Where(e => e.AerolineaId == valid.aerolineaId);

            return query.Include(e => e.Pais).Include(e => e.Puesto).Include(e => e.Tripulacion).Include(e => e.User);
        }

        protected override async Task<errorMessageDto> validPost(employeeCreationDto dtoNew, object queryParams)
        {
            aerolineaAdminValidDto valid = await aerolineaSvc.getAirlineId(dtoNew.AerolineaId);
            if (valid.error != null)
                return valid.error;
            dtoNew.AerolineaId = valid.aerolineaId;

            userCreationDto userCreation = new userCreationDto
            {
                email = dtoNew.Correo,
                password = Guid.NewGuid().ToString() + "C0NTR@S3N@",
                userName = dtoNew.UserId
            };
            List<string> roles = new List<string> { "EMPLOYEE" };
            if (dtoNew.PuestoId == 119)
                roles.Add("ADMINISTRATOR_AIRLINE");
            if (dtoNew.PuestoId == 120)
                roles.Add("AIRLINE-TACKLE");

            errorMessageDto registerResult = await userSvc.register(userCreation, roles);
            if (registerResult != null)
                return registerResult;


            userEntity user = await context.Users.FirstOrDefaultAsync(u => u.UserName == dtoNew.UserId);
            dtoNew.UserId = user.Id;

            return null;

        }
        protected override async Task modifyPost(Empleado entity, object queryParams)
        {
            entity.TripulacionId = null;
        }

        protected override async Task<errorMessageDto> validPut(employeeCreationDto dtoNew, Empleado entity, object queryParams)
        {

            if (dtoNew.PuestoId != entity.PuestoId && entity.TripulacionId != null)
                return new errorMessageDto("No se puede cambiar el puesto de un empleado que pertenece a una tripulación");

            userEntity user = await context.Users.FindAsync(entity.UserId);
            if (dtoNew.PuestoId != 119 && entity.PuestoId == 119)
                await userManager.RemoveFromRoleAsync(user, "ADMINISTRATOR_AIRLINE");
            if (dtoNew.PuestoId != 120 && entity.PuestoId == 120)
                await userManager.RemoveFromRoleAsync(user, "AIRLINE-TACKLE");
            if (dtoNew.PuestoId == 119 && entity.PuestoId != 119)
                await userManager.AddToRoleAsync(user, "ADMINISTRATOR_AIRLINE");
            if (dtoNew.PuestoId == 120 && entity.PuestoId != 120)
                await userManager.AddToRoleAsync(user, "AIRLINE-TACKLE");
            return null;
        }
        protected override Task modifyPut(Empleado entity, employeeCreationDto dtoNew, object queryParams)
        {
            dtoNew.AerolineaId = entity.AerolineaId;
            dtoNew.UserId = entity.UserId;
            return base.modifyPut(entity, dtoNew, queryParams);
        }

        [HttpGet("allAndCrew/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMINISTRATOR,ADMINISTRATOR_AIRLINE")]

        public async Task<ActionResult<List<employeeDto>>> getAllAndCrew(
            [FromRoute] long id,
            [FromQuery] employeeQuery queryParams
            )
        {
            aerolineaAdminValidDto valid = await aerolineaSvc.getAirlineId(queryParams.AerolineaId);
            if (valid.error != null)
                return BadRequest(valid.error);
            List<Empleado> empleados = await context.Empleados.Where(e => (e.TripulacionId == null || e.TripulacionId == id) && e.deleteAt == null && e.PuestoId == queryParams.PuestoId && e.AerolineaId == valid.aerolineaId).ToListAsync();
            List<employeeDto> empleadosDto = mapper.Map<List<employeeDto>>(empleados);
            return empleadosDto;
        }
        protected override async Task<errorMessageDto> validDelete(Empleado entity)
        {
            aerolineaAdminValidDto valid = await aerolineaSvc.getAirlineId(entity.AerolineaId);
            if (valid.error != null)
                return valid.error;
            if (valid.aerolineaId != entity.AerolineaId)
                return new errorMessageDto("No se puede eliminar un empleado de otra aerolínea");
            if (entity.TripulacionId != null)
                return new errorMessageDto("No se puede eliminar un empleado que pertenece a una tripulación");
            userEntity user = await context.Users.FindAsync(entity.UserId);
            if (user != null)
            {
                user.deleteAt = DateTime.Now.ToUniversalTime();
                await context.SaveChangesAsync();
            }
            return null;
        }

    }
}