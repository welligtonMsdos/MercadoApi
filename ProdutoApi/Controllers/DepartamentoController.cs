﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Produto.Domain.Dtos;
using Produto.Domain.Interfaces;
using Produto.Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProdutoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : BaseController
    {
        private readonly IDepartamentoRep _departamentoRep;
        private readonly IMapper _mapper;

        public DepartamentoController(IDepartamentoRep departamentoRep,
                                      IMapper mapper)
        {
            _departamentoRep = departamentoRep;
            _mapper = mapper;
        }       

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var departamento = await _departamentoRep.GetAll();

                var departamentoDto = _mapper.Map<ICollection<DepartamentoDto>>(departamento);

                return Response(departamentoDto);
            }
            catch (Exception ex)
            {
                return Response(ex.Message);
            }
        }

        [HttpGet("[Action]/{id}")]
        public async Task<ActionResult> GetByid(int id)
        {
            try
            {
                //var departamento = await _departamentoRep.GetById(id);

                var departamento = await _departamentoRep.GetByIdRobo(id);

                var departamentoDto = _mapper.Map<ICollection<DepartamentoDto>>(departamento);

                return Response(departamentoDto);
            }
            catch (Exception ex)
            {
                return Response(ex.Message);
            }
        }        

        [HttpGet("[Action]/{descricao}")]
        public async Task<ActionResult> GetByDescricao(string descricao)
        {
            try
            {
                var departamento = await _departamentoRep.GetByDescricao(descricao);

                return Response(departamento);
            }
            catch (Exception ex)
            {
                return Response(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Departamento>> Post([FromBody] Departamento departamento)
        {
            if (!ModelState.IsValid)
                return Response("ModelState = false");           

            try
            {
                departamento.id = null;
                await _departamentoRep.Insert(departamento);
                return Response(departamento);
            }
            catch (Exception ex)
            {
                return Response(ex.Message);
            }
        }
        
        [HttpPut]
        public async Task<ActionResult<Departamento>> Put([FromBody] Departamento departamento)
        {
            if (!ModelState.IsValid)
                return Response("ModelState = false");

            if(departamento.id == 0)
                return Response("id não pode ser zero");

            try
            {
                await _departamentoRep.Update(departamento);
                return Response(departamento);
            }
            catch (Exception ex)
            {
                return Response(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
                return Response("id não pode ser zero");

            try
            {
                await _departamentoRep.Delete(id);
                return Response("Sucess");
            }
            catch (Exception ex)
            {
                return Response(ex.Message);
            }
        }
    }
}
