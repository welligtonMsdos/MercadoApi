using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Produto.Domain.Interfaces;
using Produto.Domain.Model;

namespace Produto.Domain.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRep _objRep;
        public ProdutoService(IProdutoRep produtoRep)
        {
            _objRep = produtoRep;
        }
        public async Task Delete(int id)
        {
            await _objRep.Delete(id);
        }

        public async Task<ICollection<Model.Produto>> GetAll()
        {
            return await _objRep.GetAll();
        }

        public async Task<Model.Produto> GetById(int id)
        {
            return await _objRep.GetById(id);
        }

        public async Task Insert(Model.Produto obj)
        {
            await _objRep.Insert(obj);
        }

        public async Task Update(Model.Produto obj)
        {
            await _objRep.Update(obj);
        }
    }
}
