using AutoMapper;
using AvionesBackNet.Models;
using AvionesBackNet.Modules.Catalogues;
using AvionesBackNet.utils;
using Microsoft.EntityFrameworkCore;

namespace AvionesBackNet.Modules.Categories
{
    public class cataloguesController : controllerCommons<Catalogo, catalogueCreationDto, catalogueDto, object, object, long>
    {
        protected string codCatalogue { get; set; }
        public cataloguesController(AvionesContext context, IMapper mapper) : base(context, mapper)
        {
        }
        protected override async Task modifyPost(Catalogo entity, object queryParams)
        {
            entity.CatalogoTipoId = (await getCatalogueType()).Id;
        }

        protected Task<CatalogoTipo> getCatalogueType()
        {
            return context.CatalogoTipos.Where(db => db.Codigo == codCatalogue).FirstAsync();
        }

        protected override async Task<IQueryable<Catalogo>> modifyGet(IQueryable<Catalogo> query, object queryParams)
        {
            CatalogoTipo catalogueType = await getCatalogueType();
            return query.Where(db => db.CatalogoTipoId == catalogueType.Id);
        }
    }
}
