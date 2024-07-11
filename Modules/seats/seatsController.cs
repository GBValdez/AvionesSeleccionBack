using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AvionesBackNet.Models;
using AvionesBackNet.Modules.airline;
using AvionesBackNet.Modules.Aviones;
using AvionesBackNet.Modules.Catalogues;
using AvionesBackNet.Modules.crew;
using AvionesBackNet.Modules.seats.dtos;
using AvionesBackNet.Modules.Vuelos;
using AvionesBackNet.utils;
using AvionesBackNet.utils.writerPdf;
using iText.Barcodes;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using project.utils;
using project.utils.dto;

namespace AvionesBackNet.Modules.seats
{
    [ApiController]
    [Route("[controller]")]
    public class SeatsController : controllerCommons<Asiento, asientoDtoCreation, asientoDto, asientoQueryDto, object, long>
    {
        private readonly IDataProtector dataProtector;
        private readonly aerolineaSvc AerolineaSvc;

        public SeatsController(AvionesContext context, IMapper mapper, IDataProtectionProvider dataProvider, IConfiguration configuration, aerolineaSvc AerolineaSVC) : base(context, mapper)
        {
            this.dataProtector = dataProvider.CreateProtector(configuration["keyResetPasswordKey"]);
            AerolineaSvc = AerolineaSVC;

        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public override Task<ActionResult<resPag<asientoDto>>> get([FromQuery] int pageSize, [FromQuery] int pageNumber, [FromQuery] asientoQueryDto queryParams, [FromQuery] bool? all = false)
        {
            return base.get(pageSize, pageNumber, queryParams, all);
        }

        protected override Task<IQueryable<Asiento>> modifyGet(IQueryable<Asiento> query, asientoQueryDto queryParams)
        {
            query = query.Include(db => db.Clase);
            return base.modifyGet(query, queryParams);
        }

        [HttpGet("canEditSeats/{idPlane}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMINISTRATOR,ADMINISTRATOR_AIRLINE")]
        public async Task<ActionResult> canEditSeats(long idPlane)
        {
            Avione? plane = await context.Aviones.FirstOrDefaultAsync(p => p.Id == idPlane && p.deleteAt == null);
            if (plane == null)
            {
                return NotFound();
            }
            if (await context.Vuelos.AnyAsync(f => f.AvionId == idPlane && f.deleteAt == null && f.FechaLlegada > DateTime.UtcNow))
            {
                return BadRequest(new errorMessageDto("No se pueden modificar los asientos de un avión con vuelos pendientes"));
            }
            return Ok();
        }

        [HttpPost("saveSeats/{idPlane}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMINISTRATOR,ADMINISTRATOR_AIRLINE")]
        public async Task<ActionResult> saveSeats(long idPlane, seatPlaneDto seats)
        {
            Avione? plane = await context.Aviones.FirstOrDefaultAsync(p => p.Id == idPlane && p.deleteAt == null);
            if (plane == null)
            {
                return NotFound();
            }
            if (await context.Vuelos.AnyAsync(f => f.AvionId == idPlane && f.deleteAt == null && f.FechaLlegada > DateTime.UtcNow))
            {
                return BadRequest(new errorMessageDto("No se pueden modificar los asientos de un avión con vuelos pendientes"));
            }

            List<Asiento> seatsListDB = await context.Asientos.Where(s => s.AvionId == idPlane).ToListAsync();

            if (seatsListDB.Count >= seats.asientos.Count)
            {
                for (int i = 0; i < seats.asientos.Count; i++)
                {
                    mapper.Map(seats.asientos[i], seatsListDB[i]);
                    seatsListDB[i].AvionId = idPlane;
                    seatsListDB[i].deleteAt = null;
                }
                for (int i = seats.asientos.Count; i < seatsListDB.Count; i++)
                {
                    if (seatsListDB[i].deleteAt == null)
                        seatsListDB[i].deleteAt = DateTime.UtcNow;
                }
            }
            else
            {
                for (int i = 0; i < seatsListDB.Count; i++)
                {
                    mapper.Map(seats.asientos[i], seatsListDB[i]);
                    seatsListDB[i].deleteAt = null;
                    seatsListDB[i].AvionId = idPlane;
                }
                for (int i = seatsListDB.Count; i < seats.asientos.Count; i++)
                {
                    Asiento newSeat = mapper.Map<Asiento>(seats.asientos[i]);
                    newSeat.AvionId = idPlane;
                    context.Asientos.Add(newSeat);
                }
            }
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("getSeatsOfFly/{idFly}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "userNormal")]

        public async Task<ActionResult<avionWithSeatsDto>> getSeatsOfFly(long idFly)
        {
            string idClient = User.Claims.FirstOrDefault(c => c.Type == "clienteId")?.Value;
            if (idClient == null)
            {
                return BadRequest(new errorMessageDto("El usuario no esta autenticado como cliente"));
            }
            long idClientL = long.Parse(idClient);
            Vuelo? fly = await context.Vuelos.Where(v => v.Id == idFly && v.deleteAt == null)
            .Include(x => x.Avion)
            .FirstOrDefaultAsync();
            if (fly == null)
            {
                return null;
            }
            List<Asiento> asientos = await context.Asientos.Where(a => a.AvionId == fly.AvionId && a.deleteAt == null).Include(x => x.Clase).ToListAsync();
            List<asientoDto> asientosDto = mapper.Map<List<asientoDto>>(asientos);
            List<Boleto> boletos = await context.Boletos.Where(b => b.VueloId == idFly && b.deleteAt == null).Include(a => a.EstadoBoleto).ToListAsync();
            List<boletoDto> boletoDtos = mapper.Map<List<boletoDto>>(boletos);
            boletoDtos.ForEach(b => { b.ClienteId = b.ClienteId.Equals(idClientL) ? idClientL : -1; });

            List<VueloClase> vueloClaseList = await context.VueloClases.Where(v => v.VueloId == idFly && v.deleteAt == null).Include(x => x.Clase).ToListAsync();
            avionWithSeatsDto avionWithSeatsDto = new avionWithSeatsDto();
            avionWithSeatsDto.asientoDtos = asientosDto;
            fly.Avion.Asientos = null;
            fly.Avion.Vuelos = null;
            avionWithSeatsDto.avion = mapper.Map<AvionDto>(fly.Avion);
            avionWithSeatsDto.classList = mapper.Map<List<vueloClaseDto>>(vueloClaseList);
            avionWithSeatsDto.boletos = boletoDtos;
            return avionWithSeatsDto;
        }

        [HttpGet("getTicket/{idFly}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "userNormal")]
        public async Task<ActionResult> getTicket(long idFly)
        {
            string idClient = User.Claims.FirstOrDefault(c => c.Type == "clienteId")?.Value;
            if (idClient == null)
                return BadRequest(new errorMessageDto("El usuario no esta autenticado como cliente"));

            long idClientL = long.Parse(idClient);
            Cliente? client = await context.Clientes.FirstOrDefaultAsync(c => c.Id == idClientL && c.deleteAt == null);
            if (client == null)
                return NotFound();
            Vuelo? fly = await context.Vuelos
                .Include(b => b.AeropuertoDestino)
                .ThenInclude(b => b.Pais)
                .Include(b => b.AeropuertoOrigen)
                .ThenInclude(b => b.Pais)
                .Include(b => b.VueloClases)
                .Include(b => b.Avion)
                .Include(b => b.Avion.Aerolinea)
                .FirstOrDefaultAsync(v => v.Id == idFly && v.deleteAt == null);
            if (fly == null)
                return NotFound();
            if (fly.FechaSalida < DateTime.UtcNow)
                return BadRequest(new errorMessageDto("No se puede generar un boleto para un vuelo que ya ha salido"));

            List<Boleto> boletos = await context.Boletos
                .Where(b => b.VueloId == idFly && b.ClienteId == idClientL && b.deleteAt == null && b.EstadoBoletoId == 92)
                .Include(a => a.Asiento)
                .Include(a => a.Asiento.Clase)
                .ToListAsync();
            using (var memoryStream = new MemoryStream())
            {
                PdfWriter writer = new PdfWriter(memoryStream);
                PdfDocument pdf = new PdfDocument(writer);
                PageSize customPageSize = new PageSize(310, 900);

                pdf.SetDefaultPageSize(customPageSize);
                writterPDF writter = new writterPDF(pdf);
                //Cuerpo
                writter.title("Boleto de Vuelo");
                writter.subtitle("Información del vuelo");
                writter.subtitle2("Codigo de vuelo: ");
                writter.text(fly.Codigo);

                writter.subtitle2("Aeropuerto de origen: ");
                writter.text(fly.AeropuertoOrigen.Nombre + ", " + fly.AeropuertoOrigen.Localidad + ", " + fly.AeropuertoOrigen.Ciudad + ", " + fly.AeropuertoOrigen.Pais.Nombre);
                writter.subtitle2("Fecha de salida: ");
                writter.text(fly.FechaSalida.ToString());

                writter.subtitle2("Aeropuerto de destino: ");
                writter.text(fly.AeropuertoDestino.Nombre + ", " + fly.AeropuertoDestino.Localidad + ", " + fly.AeropuertoDestino.Ciudad + ", " + fly.AeropuertoDestino.Pais.Nombre);
                writter.subtitle2("Fecha de estimada de llegada: ");
                writter.text(fly.FechaLlegada.ToString());

                writter.subtitle("Información del cliente");
                writter.subtitle2("Pasaporte: ");
                writter.text(client.NoPasaporte);
                writter.subtitle2("Nombre: ");
                writter.text(client.Nombre);

                writter.subtitle("Información de la aerolinea");
                writter.subtitle2("Nombre: ");
                writter.text(fly.Avion.Aerolinea.Nombre);
                writter.subtitle2("Telefono: ");
                writter.text(fly.Avion.Aerolinea.Telefono);
                writter.subtitle2("Correo: ");
                writter.text(fly.Avion.Aerolinea.Email);

                writter.subtitle("Información de los asientos");
                string ids = "";
                foreach (Boleto item in boletos)
                {
                    decimal precio = fly.VueloClases.FirstOrDefault(v => v.ClaseId == item.Asiento.ClaseId).Precio;
                    writter.text(item.Asiento.Codigo + " - " + item.Asiento.Clase.name + " - Q" + Math.Round(precio, 2));
                    ids += item.Id + ",";
                }
                string qrEncrypted = dataProtector.Protect(ids);
                string encodedUrl = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(qrEncrypted));

                BarcodeQRCode qrCode = new BarcodeQRCode(encodedUrl);
                Image qrCodeImage = new Image(qrCode.CreateFormXObject(pdf));
                qrCodeImage.SetWidth(210).SetHeight(210);
                qrCodeImage.SetHorizontalAlignment(HorizontalAlignment.CENTER);
                writter.document.Add(qrCodeImage);


                writter.document.Close();
                string name = "Ticket_" + DateTime.UtcNow.ToString("dd-MM-yyyy") + ".pdf";
                return File(memoryStream.ToArray(), "application/pdf", name);
            }


        }


        [HttpGet("getTackleTicket/{ticket}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "AIRLINE-TACKLE,ADMINISTRATOR,ADMINISTRATOR_AIRLINE")]
        public async Task<ActionResult<ticketCompleteDto>> getTackleTicket(string ticket, [FromQuery] long? AerolineaId)
        {
            List<Boleto> boletos = await getTickets(ticket);
            if (boletos == null)
                return BadRequest(new errorMessageDto("El ticket no es valido"));
            if (boletos.Count == 0)
                return BadRequest(new errorMessageDto("El ticket no es valido"));
            long idClient = boletos[0].ClienteId;
            Cliente? client = await context.Clientes.FirstOrDefaultAsync(c => c.Id == idClient && c.deleteAt == null);
            if (client == null)
                return NotFound();
            Vuelo? fly = await context.Vuelos.Where(v => v.Id == boletos[0].VueloId && v.deleteAt == null)
                .Include(b => b.AeropuertoDestino)
                .ThenInclude(b => b.Pais)
                .Include(b => b.AeropuertoOrigen)
                .ThenInclude(b => b.Pais)
                .Include(b => b.VueloClases)
                .ThenInclude(b => b.Clase)
                .Include(b => b.Avion)
                .FirstOrDefaultAsync();

            if (fly == null)
                return NotFound();
            aerolineaAdminValidDto valid = await AerolineaSvc.getAirlineId(AerolineaId);
            if (valid.error != null)
                return BadRequest(valid.error);
            if (valid.aerolineaId != fly.Avion.AerolineaId)
                return BadRequest(
                    new errorMessageDto("El ticket no es valido")
                );
            ticketCompleteDto ticketCompleteDto = new ticketCompleteDto();
            ticketCompleteDto.cliente = mapper.Map<clienteDto>(client);
            ticketCompleteDto.vuelo = mapper.Map<vueloDto>(fly);
            ticketCompleteDto.boletos = mapper.Map<List<boletoDto>>(boletos);
            return ticketCompleteDto;
        }

        [HttpPost("completeTackleTicket/{ticket}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "AIRLINE-TACKLE,ADMINISTRATOR,ADMINISTRATOR_AIRLINE")]
        public async Task<ActionResult> completeTackleTicket([FromRoute] string ticket, [FromQuery(Name = "AerolineaId")] long? AerolineaId)
        {

            List<Boleto> boletos = await getTickets(ticket);
            if (boletos == null)
                return BadRequest(new errorMessageDto("El ticket no es valido"));

            if (boletos.Count == 0)
                return BadRequest(new errorMessageDto("Los boletos ya han sido abordados"));
            long idClient = boletos[0].ClienteId;
            if (!(await context.Clientes.AnyAsync(b => b.Id == idClient)))
                return BadRequest(new errorMessageDto("El cliente no existe"));

            Vuelo? fly = await context.Vuelos.Where(v => v.Id == boletos[0].VueloId && v.deleteAt == null)
                .Include(b => b.Avion)
                .FirstOrDefaultAsync();
            if (fly == null)
                return NotFound();
            aerolineaAdminValidDto valid = await AerolineaSvc.getAirlineId(AerolineaId);
            if (valid.error != null)
                return BadRequest(valid.error);
            if (valid.aerolineaId != fly.Avion.AerolineaId)
                return BadRequest(
                    new errorMessageDto("El boleto es invalido")
                );


            foreach (Boleto item in boletos)
            {
                item.EstadoBoletoId = 95;
            }
            await context.SaveChangesAsync();
            return Ok();
        }

        private async Task<List<Boleto>> getTickets(string ticketEncrypted)
        {
            try
            {
                byte[] decodedTicketUrl = WebEncoders.Base64UrlDecode(ticketEncrypted);
                string normalTicket = Encoding.UTF8.GetString(decodedTicketUrl);
                string decrypted = dataProtector.Unprotect(normalTicket);
                string[] ids = decrypted.Split(",");
                IQueryable<Boleto> queryBoletos = context.Boletos.Where(b => ids.Contains(b.Id.ToString()))
                    .Include(t => t.Asiento);
                long countTicket = await queryBoletos.Where(b => b.EstadoBoletoId == 92).CountAsync();
                if (countTicket != ids.Count() - 1)
                {
                    long countTicketTackle = await queryBoletos.Where(b => b.EstadoBoletoId == 95).CountAsync();
                    if (countTicketTackle == ids.Count() - 1)
                        return [];
                    else
                        return null;
                }

                return await queryBoletos.Where(b => b.EstadoBoletoId == 92)
                    .ToListAsync();
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }

}