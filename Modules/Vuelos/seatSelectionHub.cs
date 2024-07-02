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
            Vuelo vuelo = await _context.Vuelos.Where(v => v.Id == long.Parse(vueloId) && v.deleteAt == null).FirstOrDefaultAsync();
            if (vuelo == null)
            {
                await Clients.Caller.SendAsync("ErrorMessage", "Vuelo no encontrado");
                return;
            }
            if (vuelo.FechaSalida < DateTime.UtcNow)
            {
                await Clients.Caller.SendAsync("ErrorMessage", "El vuelo ya ha salido");
                return;
            }
            string idClient = Context.User.Claims.FirstOrDefault(c => c.Type == "clienteId")?.Value;
            if (idClient == null)
            {
                await Clients.Caller.SendAsync("ErrorMessage", "El usuario no esta autenticado como cliente");
                return;
            }

            Context.Items["vueloId"] = vueloId;
            await Groups.AddToGroupAsync(Context.ConnectionId, vueloId);
        }
        public async Task LeaveGroup(string vueloId)
        {
            List<Boleto> boletos = await _context.Boletos.Where(b => b.VueloId == long.Parse(vueloId) && b.deleteAt == null && b.EstadoBoletoId == 93).ToListAsync();
            boletos.ForEach(b => b.EstadoBoletoId = 94);
            await _context.SaveChangesAsync();
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, vueloId);
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            string vueloId = Context.Items["vueloId"]?.ToString();
            if (!string.IsNullOrEmpty(vueloId))
            {
                await LeaveGroup(vueloId);
            }
            await base.OnDisconnectedAsync(exception);
        }
        public async Task SendSeatSelections(string asientoId, string vueloId)
        {
            long idClient = long.Parse(Context.User.Claims.FirstOrDefault(c => c.Type == "clienteId")?.Value);
            long vueloIdL = long.Parse(vueloId);
            long asientoIdL = long.Parse(asientoId);
            Boleto boleto = await _context.Boletos
                .Where(b => b.AsientoId == asientoIdL && b.VueloId == vueloIdL && b.deleteAt == null)
                .FirstOrDefaultAsync();

            if (boleto == null)
            {

                boleto = new Boleto
                {
                    AsientoId = asientoIdL,
                    VueloId = vueloIdL,
                    updateAt = DateTime.UtcNow,
                    createAt = DateTime.UtcNow,
                    ClienteId = idClient,
                    EstadoBoletoId = 93,
                    CantidadMaletasAdquiridas = 0,
                    CantidadMaletasPresentadas = 0
                };
                await _context.Boletos.AddAsync(boleto);
            }
            else if (boleto.EstadoBoletoId != 92)
            {
                if (boleto.EstadoBoletoId == 93)
                    boleto.EstadoBoletoId = 94;
                else if (boleto.EstadoBoletoId == 94)
                    boleto.EstadoBoletoId = 93;

                boleto.updateAt = DateTime.UtcNow;
                boleto.ClienteId = idClient;
            }
            await _context.SaveChangesAsync();

            List<Boleto> boletos = await _context.Boletos.Where(b => b.VueloId == vueloIdL && b.deleteAt == null).Include(a => a.EstadoBoleto).ToListAsync();
            boletos.ForEach(b => { b.ClienteId = b.ClienteId.Equals(idClient) ? idClient : -1; });
            await Clients.Group(vueloId).SendAsync("ReceiveSeatSelection", boletos);

        }
    }
}