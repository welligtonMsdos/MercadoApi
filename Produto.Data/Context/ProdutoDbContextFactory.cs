using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Produto.Data.Context
{
    public class ProdutoDbContextFactory : IDesignTimeDbContextFactory<ProdutoDbContext>
    {
        public ProdutoDbContextFactory()
        {

        }
        public ProdutoDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProdutoDbContext>();
            optionsBuilder.UseSqlServer("");
            return new ProdutoDbContext(optionsBuilder.Options);
        }
    }
}
