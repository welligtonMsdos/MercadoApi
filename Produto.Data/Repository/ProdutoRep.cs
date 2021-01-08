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
    public class ProdutoRep : Repository<Domain.Model.Produto>, IProdutoRep
    {
        public ProdutoRep(ProdutoDbContext ctx) : base(ctx)
        {

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
