using AutoMapper;

namespace ProdutoApi.Configurations
{
    public class MapConfig : Profile
    {
        public MapConfig()
        {

            #region PRODUTO

            CreateMap<Produto.Domain.Model.Produto, Produto.Domain.Dtos.ProdutoDto>()
                .ForMember(m => m.departamento, o => o.MapFrom(s => s.Departamento.descricao));

            CreateMap<Produto.Domain.Model.Produto, Produto.Domain.Dtos.ProdutoAllDto>()
               .ForMember(m => m.departamento, o => o.MapFrom(s => s.Departamento.descricao));

            #endregion
        }
    }
}
