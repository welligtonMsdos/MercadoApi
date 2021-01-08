using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Produto.Domain.Interfaces;
using Produto.Domain.Model;

namespace ProdutoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : BaseController
    {
        private readonly IDepartamentoRep _departamentoRep;
        private readonly IDepartamentoService _departamentoService;

        public DepartamentoController(IDepartamentoRep departamentoRep,
                                      IDepartamentoService departamentoService)
        {
            _departamentoRep = departamentoRep;
            _departamentoService = departamentoService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var departamento = await _departamentoRep.GetAll();

                return Response(departamento);
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
                var departamento = await _departamentoRep.GetById(id);

                return Response(departamento);
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
                await _departamentoService.Insert(departamento);
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
                await _departamentoService.Update(departamento);
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
                await _departamentoService.Delete(id);
                return Response("Sucess");
            }
            catch (Exception ex)
            {
                return Response(ex.Message);
            }
        }
    }
}
