using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AvionesBackNet.Models;
using AvionesBackNet.Modules.seats;
using AvionesBackNet.Modules.Vuelos.dto;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace AvionesBackNet.Modules.Vuelos
{
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


        public async Task SendSeatSelections(string asientoId, string vueloId)
        {
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
                    ClienteId = 1,
                    EstadoBoletoId = 29,
                    CantidadMaletasAdquiridas = 0,
                    CantidadMaletasPresentadas = 0
                };
                await _context.Boletos.AddAsync(boleto);
                await _context.SaveChangesAsync();
            }
            else if (boleto.EstadoBoletoId == 30)
            {
                boleto.EstadoBoletoId = 29;
                boleto.updateAt = DateTime.UtcNow;
                boleto.ClienteId = 1;
                await _context.SaveChangesAsync();
            }
            else if (boleto.EstadoBoletoId == 29)
            {
                boleto.EstadoBoletoId = 30;
                boleto.updateAt = DateTime.UtcNow;
                boleto.ClienteId = 1;
                await _context.SaveChangesAsync();
            }

            var asientosDto = await _seatSvc.getSeatsByFlyId(vueloIdL);
            await Clients.All.SendAsync("ReceiveSeatSelection", asientosDto);

        }
    }
}