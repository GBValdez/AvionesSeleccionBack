using AutoMapper;
using AvionesBackNet.Models;
using AvionesBackNet.Modules.Aeropuertos;
using AvionesBackNet.Modules.Aviones;
using AvionesBackNet.Modules.Catalogues;
using AvionesBackNet.Modules.Categories;
using AvionesBackNet.Modules.Paises;
using AvionesBackNet.Modules.seats;
using AvionesBackNet.Modules.Vuelos;
using AvionesBackNet.Modules.Vuelos.dto;

namespace AvionesBackNet.utils
{
    public class autoMapperProfiles : Profile
    {
        public autoMapperProfiles()
        {
            //Catalogos
            CreateMap<Catalogo, catalogueDto>();
            CreateMap<catalogueCreationDto, Catalogo>();
            CreateMap<asientoDtoCreation, Asiento>();
            CreateMap<Asiento, asientoDto>();
            CreateMap<Avione, AvionDto>();
            CreateMap<AvionCreationDto, Avione>();
            CreateMap<Boleto, boletoDto>();
            CreateMap<Cliente, clienteDto>();
            CreateMap<Paise, paisDto>();
            CreateMap<Vuelo, vueloDto>();
            CreateMap<VueloClase, vueloClaseDto>();
            CreateMap<vueloClaseDtoCreation, VueloClase>();
            CreateMap<vueloDtoCreation, Vuelo>();
            CreateMap<Aeropuerto, AeropuertoDto>();
            CreateMap<AeropuertoDtoCreation, Aeropuerto>();
            CreateMap<Aerolinea, aerolineaDto>();
        }
    }
}
