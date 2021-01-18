using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Produto.Domain.Dtos;
using Produto.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProdutoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : BaseController
    {
        private readonly IProdutoRep _produtoRep;        
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoRep produtoRep,
                                 IMapper mapper)
        {
            _produtoRep = produtoRep;         
            _mapper = mapper;
        }

        [HttpGet("[Action]")]
        public async Task<ActionResult> GetAllByRobo()
        {
            try
            {
                var produto = await _produtoRep.GetAllProdutos();

                var produtoDto = _mapper.Map<ICollection<ProdutoAllDto>>(produto);

                return Ok(produtoDto);
            }
            catch (Exception ex)
            {
                return Response(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var produto = await _produtoRep.GetAllProdutos();

                var produtoDto = _mapper.Map<ICollection<ProdutoAllDto>>(produto);

                return Response(produtoDto);
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

                return Ok(produtoDto);                
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
                await _produtoRep.Insert(produto);
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
                await _produtoRep.Update(produto);
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
                await _produtoRep.Delete(id);
                return Response("Sucess");
            }
            catch (Exception ex)
            {
                return Response(ex.Message);
            }
        }

    }
}
