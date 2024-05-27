using AutoMapper;
using AvionesBackNet.Models;
using AvionesBackNet.Modules.Aviones;
using AvionesBackNet.Modules.Catalogues;
using AvionesBackNet.Modules.Categories;
using AvionesBackNet.Modules.seats;

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
        }
    }
}
