using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using project.users;
using project.users.dto;
using project.utils.dto;
using project.utils.services;

namespace AvionesBackNet.users
{
    public class userSvc
    {
        private readonly UserManager<userEntity> userManager;
        private readonly emailService emailService;
        private readonly IConfiguration configuration;


        public async Task<IActionResult> register(userCreationDto credentials, IList<string> roles)
        {
            if (await userManager.FindByEmailAsync(credentials.email) != null)
                return new BadRequestObjectResult(new errorMessageDto("El correo ya esta en uso"));
            if (await userManager.FindByNameAsync(credentials.userName) != null)
                return new BadRequestObjectResult(new errorMessageDto("El nombre de usuario ya esta en uso"));
            userEntity user = new userEntity() { UserName = credentials.userName, Email = credentials.email };

            IdentityResult result = await userManager.CreateAsync(user, credentials.password);
            if (!result.Succeeded)
                return new BadRequestObjectResult(result.Errors.Select(e => new errorMessageDto(e.Description)));
            IdentityResult roleResult = await userManager.AddToRolesAsync(user, roles);
            if (!roleResult.Succeeded)
                return new BadRequestObjectResult(roleResult.Errors.Select(e => new errorMessageDto(e.Description)));

            string token = await userManager.GenerateEmailConfirmationTokenAsync(user);
            string encodedToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
            emailService.SendEmail(new emailSendDto
            {
                email = credentials.email,
                subject = "Confirmacion de correo",
                message = $"<h1>Correo de confirmación Aeropuerto</h1> <a href='{configuration["FrontUrl"]}/user/confirmEmail?email={credentials.email}&token={encodedToken}'>Confirmar correo</a>"
            });
            return new OkResult();
        }
    }
}