using System;
using System.Collections.Generic;
using System.Text;
using Produto.Domain.Model;
using System.Threading.Tasks;

namespace Produto.Domain.Interfaces
{
    public interface IProdutoRep : IRepository<Model.Produto>
    {
        Task<ICollection<Model.Produto>> GetByDepartamentoId(int departamentoId);
    }
}
