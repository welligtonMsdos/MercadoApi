using Microsoft.EntityFrameworkCore;
using Produto.Domain.Interfaces;
using Produto.Domain.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Produto.Data.Repository
{
    public class DepartamentoRep : Repository<Departamento>, IDepartamentoRep
    {
        public DepartamentoRep(ProdutoDbContext ctx) : base(ctx)
        {
        }

        public async Task<ICollection<Departamento>> GetByDescricao(string descricao)
        {
            return await _dbSet
                .Where(m => m.descricao == descricao)
                .ToListAsync();
        }
    }
}
