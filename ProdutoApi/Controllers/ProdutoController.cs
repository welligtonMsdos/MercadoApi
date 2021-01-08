using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Produto.Domain.Interfaces;
using Produto.Domain.Model;
using AutoMapper;
using Produto.Domain.Dtos;

namespace ProdutoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : BaseController
    {
        private readonly IProdutoRep _produtoRep;
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoRep produtoRep,
                                 IProdutoService produtoService,
                                 IMapper mapper)
        {
            _produtoRep = produtoRep;
            _produtoService = produtoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var produto = await _produtoRep.GetAll();

                return Response(produto);
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
                var produto = await _produtoRep.GetById(id);

                return Response(produto);
            }
            catch (Exception ex)
            {
                return Response(ex.Message);
            }
        }

        [HttpGet("[Action]/{departamentoId}")]
        public async Task<ActionResult> GetByDepartamentoId(int departamentoId)
        {
            try
            {
                var produto = await _produtoRep.GetByDepartamentoId(departamentoId);

                var produtoDto = _mapper.Map<ICollection<ProdutoDto>>(produto);

                return Response(produtoDto);
            }
            catch (Exception ex)
            {
                return Response(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Produto.Domain.Model.Produto>> Post([FromBody] Produto.Domain.Model.Produto produto)
        {
            if (!ModelState.IsValid)
                return Response("ModelState = false");

            try
            {
                produto.id = null;
                await _produtoService.Insert(produto);
                return Response(produto);
            }
            catch (Exception ex)
            {
                return Response(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Produto.Domain.Model.Produto>> Put([FromBody] Produto.Domain.Model.Produto produto)
        {
            if (!ModelState.IsValid)
                return Response("ModelState = false");

            if (produto.id == 0)
                return Response("id não pode ser zero");

            try
            {
                await _produtoService.Update(produto);
                return Response(produto);
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
                await _produtoService.Delete(id);
                return Response("Sucess");
            }
            catch (Exception ex)
            {
                return Response(ex.Message);
            }
        }

    }
}
