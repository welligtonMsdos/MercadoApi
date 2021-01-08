using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Produto.Data.Context;
using Produto.Domain.Interfaces;
using Produto.Domain.Model;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
