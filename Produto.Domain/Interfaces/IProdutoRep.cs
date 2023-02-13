using System.Collections.Generic;
using System.Threading.Tasks;

namespace Produto.Domain.Interfaces
{
    public interface IProdutoRep : IRepository<Model.Produto>
    {
        Task<ICollection<Model.Produto>> GetAllProdutos();
        Task<ICollection<Model.Produto>> GetByDepartamentoId(int departamentoId);
        Task<Model.Produto> GetProdutoById(int id);
    }
}
