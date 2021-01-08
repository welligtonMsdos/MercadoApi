using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Produto.Domain.Model;

namespace ProdutoApi.Configurations
{
    public class MapConfig : Profile
    {
        public MapConfig()
        {

            #region PRODUTO

            CreateMap<Produto.Domain.Model.Produto, Produto.Domain.Dtos.ProdutoDto>()
                .ForMember(m => m.departamento, o => o.MapFrom(s => s.Departamento.descricao));

            #endregion
        }
    }
}
