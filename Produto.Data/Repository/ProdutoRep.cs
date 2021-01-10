using Microsoft.EntityFrameworkCore;
using Produto.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Produto.Data.Repository
{
    public class ProdutoRep : Repository<Domain.Model.Produto>, IProdutoRep
    {
        public ProdutoRep(ProdutoDbContext ctx) : base(ctx)
        {

        }

        public async Task<ICollection<Domain.Model.Produto>> GetAllProdutos()
        {
            return await _dbSet
                .Include(m => m.Departamento)               
                .ToListAsync();
        }

        public async Task<ICollection<Domain.Model.Produto>> GetByDepartamentoId(int departamentoId)
        {
            return await _dbSet
                 .Include(m => m.Departamento)
                 .Where(m => m.departamento_Id == departamentoId)
                 .ToListAsync();
        }
    }
}
