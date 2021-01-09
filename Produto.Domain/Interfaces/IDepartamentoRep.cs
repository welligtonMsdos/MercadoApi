using Produto.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Produto.Domain.Interfaces
{
    public interface IDepartamentoRep : IRepository<Departamento>
    {
        Task<ICollection<Departamento>> GetByDescricao(string descricao);
    }
}
