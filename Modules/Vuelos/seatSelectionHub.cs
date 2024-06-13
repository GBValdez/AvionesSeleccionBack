using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using AvionesBackNet.Models;
using AvionesBackNet.Modules.seats;
using AvionesBackNet.Modules.Vuelos.dto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace AvionesBackNet.Modules.Vuelos
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class seatSelectionHub : Hub
    {
        private AvionesContext _context;
        private readonly IMapper _mapper;
        private readonly seatSvc _seatSvc;

        public seatSelectionHub(AvionesContext context, IMapper mapper, seatSvc seatSvc)
        {
            _context = context;
            _mapper = mapper;
            _seatSvc = seatSvc;
        }

        public async Task JoinGroup(string vueloId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, vueloId);
        }
        public async Task LeaveGroup(string vueloId)
        {

            await Groups.RemoveFromGroupAsync(Context.ConnectionId, vueloId);
        }

        public async Task SendSeatSelections(string asientoId, string vueloId)
        {
            string idClient = Context.User.Claims.FirstOrDefault(c => c.Type == "clienteId")?.Value;

            if (idClient == null)
            {
                await Clients.Caller.SendAsync("ErrorMessage", "User is not authenticated as a client.");
                return;
            }

            long vueloIdL = long.Parse(vueloId);
            long asientoIdL = long.Parse(asientoId);
            Boleto boleto = await _context.Boletos
                .Where(b => b.AsientoId == asientoIdL && b.VueloId == vueloIdL)
                .FirstOrDefaultAsync();

            if (boleto == null)
            {

                boleto = new Boleto
                {
                    AsientoId = asientoIdL,
                    VueloId = vueloIdL,
                    updateAt = DateTime.UtcNow,
                    createAt = DateTime.UtcNow,
                    ClienteId = long.Parse(idClient),
                    EstadoBoletoId = 93,
                    CantidadMaletasAdquiridas = 0,
                    CantidadMaletasPresentadas = 0
                };
                await _context.Boletos.AddAsync(boleto);
                await _context.SaveChangesAsync();
            }
            else if (boleto.EstadoBoletoId == 93)
            {
                boleto.EstadoBoletoId = 94;
                boleto.updateAt = DateTime.UtcNow;
                boleto.ClienteId = long.Parse(idClient);
                await _context.SaveChangesAsync();
            }
            else if (boleto.EstadoBoletoId == 94)
            {
                boleto.EstadoBoletoId = 93;
                boleto.updateAt = DateTime.UtcNow;
                boleto.ClienteId = long.Parse(idClient);
                await _context.SaveChangesAsync();
            }
            var asientosDto = await _seatSvc.getSeatsByFlyId(vueloIdL);
            await Clients.Group(vueloId).SendAsync("ReceiveSeatSelection", asientosDto);

        }
    }
}