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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "userNormal")]
    public class seatSelectionHub : Hub
    {
        private AvionesContext _context;
        private readonly IMapper _mapper;

        public seatSelectionHub(AvionesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
            long idClient = long.Parse(Context.User.Claims.FirstOrDefault(c => c.Type == "clienteId")?.Value);
            List<Boleto> boletos = await _context.Boletos.Where(b => b.VueloId == long.Parse(vueloId) && b.deleteAt == null && b.EstadoBoletoId == 93 && b.ClienteId == idClient).ToListAsync();
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
                Vuelo vuelo = await _context.Vuelos.FirstOrDefaultAsync(v => v.Id == vueloIdL && v.deleteAt == null);
                Asiento asiento = await _context.Asientos.FirstOrDefaultAsync(a => a.Id == asientoIdL && a.deleteAt == null);
                string code = $"{vuelo.Codigo}_{asiento.Codigo}";

                boleto = new Boleto
                {
                    AsientoId = asientoIdL,
                    VueloId = vueloIdL,
                    updateAt = DateTime.UtcNow,
                    createAt = DateTime.UtcNow,
                    ClienteId = idClient,
                    EstadoBoletoId = 93,
                    CantidadMaletasPresentadas = 0,
                    Codigo = code,
                    ClaseId = asiento.ClaseId

                };
                await _context.Boletos.AddAsync(boleto);
                await _context.SaveChangesAsync();
            }
            else if (boleto.EstadoBoletoId != 92)
            {
                bool changeState = false;
                if (boleto.EstadoBoletoId == 93 && boleto.ClienteId == idClient)
                {
                    boleto.EstadoBoletoId = 94;
                    changeState = true;
                }
                else if (boleto.EstadoBoletoId == 94)
                {
                    boleto.EstadoBoletoId = 93;
                    boleto.ClienteId = idClient;
                    changeState = true;

                }
                if (changeState)
                {
                    boleto.updateAt = DateTime.UtcNow;
                    await _context.SaveChangesAsync();
                }

            }

            await sendTickets(vueloIdL, idClient);
        }

        public async Task VacateSeats(string vueloId, string asientoId)
        {
            long idClient = long.Parse(Context.User.Claims.FirstOrDefault(c => c.Type == "clienteId")?.Value);
            long vueloIdL = long.Parse(vueloId);
            List<long> asientosId = asientoId.Split(',').Select(long.Parse).ToList();
            List<Boleto> boletos = await _context.Boletos.Where(b => b.VueloId == vueloIdL && asientosId.Contains(b.AsientoId) && b.deleteAt == null && b.ClienteId == idClient && b.EstadoBoletoId == 93).ToListAsync();
            boletos.ForEach(b => b.EstadoBoletoId = 94);
            await _context.SaveChangesAsync();

            await sendTickets(vueloIdL, idClient);
        }

        public async Task PaySeats(string vueloId, string asientoId)
        {
            List<long> seatsId = asientoId.Split(',').Select(long.Parse).ToList();
            if (seatsId.Count == 0)
                await Clients.Caller.SendAsync("ErrorMessage", "No se han seleccionado asientos");
            Vuelo? fly = await _context.Vuelos.FirstOrDefaultAsync(f => f.Id == long.Parse(vueloId) && f.deleteAt == null);
            if (fly == null)
                await Clients.Caller.SendAsync("ErrorMessage", "Vuelo no encontrado");

            if (fly.FechaSalida < DateTime.UtcNow)
                await Clients.Caller.SendAsync("ErrorMessage", "El vuelo ya ha salido");

            string idClient = Context.User.Claims.FirstOrDefault(c => c.Type == "clienteId")?.Value;
            if (idClient == null)
                await Clients.Caller.SendAsync("ErrorMessage", "El usuario no esta autenticado como cliente");
            List<Boleto> tickets = await _context.Boletos.Where(b => b.VueloId == long.Parse(vueloId) && b.deleteAt == null && b.EstadoBoletoId == 93 && seatsId.Contains(b.AsientoId) && b.ClienteId == long.Parse(idClient)).ToListAsync();
            if (!tickets.Count.Equals(seatsId.Count))
            {
                await Clients.Caller.SendAsync("ErrorMessage", "Algunos de los asientos seleccionados ya han sido pagados");
            }
            foreach (Boleto item in tickets)
            {
                item.updateAt = DateTime.UtcNow;
                item.EstadoBoletoId = 92;
                item.Codigo = item.Codigo + "_" + item.Id;


            }
            await _context.SaveChangesAsync();

            await sendTickets(long.Parse(vueloId), long.Parse(idClient));
        }

        private async Task sendTickets(long vueloId, long idClient)
        {
            List<Boleto> boletosAll = await _context.Boletos.Where(b => b.VueloId == vueloId && b.deleteAt == null).Include(a => a.EstadoBoleto).ToListAsync();
            List<boletoDto> boletoDtos = _mapper.Map<List<boletoDto>>(boletosAll);
            boletoDtos.ForEach(b =>
            {
                b.ClienteId = b.ClienteId.Equals(idClient) ? idClient : -1;
                b.Codigo = "";
                b.ClaseId = -1;
            });
            await Clients.Group(vueloId + "").SendAsync("ReceiveSeatSelection", boletoDtos);
        }
    }
}