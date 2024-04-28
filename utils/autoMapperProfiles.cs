﻿using AutoMapper;
using AvionesBackNet.Models;
using AvionesBackNet.Modules.Catalogues;
using AvionesBackNet.Modules.Categories;

namespace AvionesBackNet.utils
{
    public class autoMapperProfiles : Profile
    {
        public autoMapperProfiles()
        {
            //Catalogos
            CreateMap<Catalogo, catalogueDto>();
            CreateMap<catalogueCreationDto, Catalogo>();

        }
    }
}
