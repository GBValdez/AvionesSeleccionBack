using AutoMapper;
using AvionesBackNet.Models;
using AvionesBackNet.utils.Catalogues;
using Microsoft.EntityFrameworkCore;
using project.utils.catalogues.dto;

namespace project.utils.catalogues
{
    public class cataloguesController : controllerCommons<Catalogo, catalogueCreationDto, catalogueDto, catalogueQueryDto, object, long>
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
            return context.CatalogoTipos.Where(db => db.code == codCatalogue).FirstOrDefaultAsync();
        }

        protected override async Task<IQueryable<Catalogo>> modifyGet(IQueryable<Catalogo> query, catalogueQueryDto queryParams)
        {
            CatalogoTipo catalogueType = await getCatalogueType();
            return query.Where(db => db.CatalogoTipoId == catalogueType.Id);
        }
    }
}
