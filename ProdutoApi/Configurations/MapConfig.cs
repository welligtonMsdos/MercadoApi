﻿using AutoMapper;
using Produto.Domain.Dtos;
using Produto.Domain.Model;

namespace ProdutoApi.Configurations
{
    public class MapConfig : Profile
    {
        public MapConfig()
        {

            #region DEPARTAMENTO

            CreateMap<Departamento, DepartamentoDto>().ReverseMap();

            #endregion

            #region PRODUTO

            CreateMap<Produto.Domain.Model.Produto, ProdutoDto>()
                .ForMember(m => m.departamento, o => o.MapFrom(s => s.Departamento.descricao));

            CreateMap<Produto.Domain.Model.Produto, ProdutoAllDto>()
               .ForMember(m => m.departamentoId, o => o.MapFrom(s => s.Departamento.id))
               .ForMember(m => m.departamento, o => o.MapFrom(s => s.Departamento.descricao));

            #endregion
        }
    }
}
