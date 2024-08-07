using AutoMapper;
using AvionesBackNet.Models;
using AvionesBackNet.Modules.Aeropuertos;
using AvionesBackNet.Modules.airline;
using AvionesBackNet.Modules.Aviones;
using AvionesBackNet.Modules.country;
using AvionesBackNet.Modules.crew;
using AvionesBackNet.Modules.destinos;
using AvionesBackNet.Modules.Empleados;
using AvionesBackNet.Modules.Paises;
using AvionesBackNet.Modules.seats;
using AvionesBackNet.Modules.Vuelos;
using AvionesBackNet.Modules.Vuelos.dto;
using project.roles;
using project.roles.dto;
using project.users;
using project.users.dto;
using project.utils.catalogues.dto;

namespace project.utils.autoMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<userEntity, userDto>()
            .ForMember(userDtoId => userDtoId.isActive, options => options.MapFrom(src => src.deleteAt == null));
            ;

            CreateMap<rolEntity, rolDto>();
            CreateMap<rolCreationDto, rolEntity>();

            CreateMap<Catalogo, catalogueDto>();
            CreateMap<catalogueCreationDto, Catalogo>();
            CreateMap<asientoDtoCreation, Asiento>();
            CreateMap<Asiento, asientoDto>();
            CreateMap<Avione, AvionDto>();
            CreateMap<AvionCreationDto, Avione>();
            CreateMap<Boleto, boletoDto>();
            CreateMap<Cliente, clienteDto>();
            CreateMap<clienteCreationDto, Cliente>();
            CreateMap<Paise, paisDto>();
            CreateMap<countryCreationDto, Paise>();
            CreateMap<Vuelo, vueloDto>();
            CreateMap<VueloClase, vueloClaseDto>();
            CreateMap<vueloClaseDtoCreation, VueloClase>();
            CreateMap<vueloDtoCreation, Vuelo>();
            CreateMap<Aeropuerto, AeropuertoDto>();
            CreateMap<AeropuertoDtoCreation, Aeropuerto>();
            CreateMap<Aerolinea, aerolineaDto>();
            CreateMap<airlineCreationDto, Aerolinea>();

            CreateMap<Empleado, employeeDto>();
            CreateMap<employeeCreationDto, Empleado>();
            CreateMap<Tripulacione, crewDto>();
            CreateMap<crewPersonalDto, Tripulacione>();

            CreateMap<AerolineaAeropuerto, destinoDto>();
            CreateMap<destinoCreationDto, AerolineaAeropuerto>();
        }

    }
}