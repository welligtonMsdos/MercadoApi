using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Produto.Domain.Interfaces;
using Produto.Domain.Model;

namespace Produto.Domain.Services
{
    public class DepartamentoService : IDepartamentoService 
    {
        private readonly IDepartamentoRep _objRep;
        public DepartamentoService(IDepartamentoRep departamentoRep)
        {
            _objRep = departamentoRep;
        }

        public async Task Delete(int id)
        {
            await _objRep.Delete(id);
        }

        public async Task<ICollection<Departamento>> GetAll()
        {
            return await _objRep.GetAll();
        }

        public async Task<Departamento> GetById(int id)
        {
            return await _objRep.GetById(id);
        }

        public async Task Insert(Departamento obj)
        {
            await _objRep.Insert(obj);
        }

        public async Task Update(Departamento obj)
        {
            await _objRep.Update(obj);
        }
    }
}
