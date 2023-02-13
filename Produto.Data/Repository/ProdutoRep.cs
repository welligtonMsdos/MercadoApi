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
                 .Where(m => m.departamentoId == departamentoId)
                 .ToListAsync();
        }

        public async Task<Domain.Model.Produto> GetProdutoById(int id)
        {
            return await _dbSet.Include(x => x.Departamento).FirstOrDefaultAsync(x => x.id == id);
        }
    }
}
