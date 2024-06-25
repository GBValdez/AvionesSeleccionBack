using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AvionesBackNet.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using project.users;
using project.utils.dto;

namespace AvionesBackNet.Modules.airline
{
    public class aerolineaSvc
    {
        private IHttpContextAccessor httpContextAccessor;
        private AvionesContext context;
        private UserManager<userEntity> userManager;
        public aerolineaSvc(AvionesContext context, UserManager<userEntity> userManager, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<aerolineaAdminValidDto> getAirlineId(long? aerolineaId)
        {
            string idUser = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            userEntity userLoged = await context.Users.Where(u => u.Id == idUser).FirstOrDefaultAsync();
            if (userLoged == null)
                return new aerolineaAdminValidDto { error = new errorMessageDto("Usuario no encontrado") };
            IList<string> rolesLoged = await userManager.GetRolesAsync(userLoged);
            Empleado empleado = await context.Empleados.Where(e => e.UserId == idUser && e.deleteAt == null).FirstOrDefaultAsync();
            if (rolesLoged.Contains("ADMINISTRATOR_AIRLINE"))
            {
                if (empleado == null)
                    return new aerolineaAdminValidDto { error = new errorMessageDto("El administrador de aerlinea no tiene el puesto de administrador de aerolínea") };

                if (empleado.PuestoId != 119)
                    return new aerolineaAdminValidDto { error = new errorMessageDto("El administrador de aerlinea no tiene el puesto de administrador de aerolínea") };
                return new aerolineaAdminValidDto { aerolineaId = empleado.AerolineaId };
            }

            if (rolesLoged.Contains("ADMINISTRATOR") && aerolineaId == null)
            {
                return new aerolineaAdminValidDto { error = new errorMessageDto("El administrador debe especificar la aerolínea") };
            }
            return new aerolineaAdminValidDto { aerolineaId = aerolineaId };
        }

    }
}