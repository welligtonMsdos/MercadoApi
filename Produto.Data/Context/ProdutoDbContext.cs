using Microsoft.EntityFrameworkCore;
using Produto.Domain.Model;

namespace Produto.Data
{
    public class ProdutoDbContext : DbContext
    {
       
        public ProdutoDbContext(DbContextOptions<ProdutoDbContext> options) : base(options)
        {
        }

        #region DbSets
        public DbSet<Departamento> departamento { get; set; }
        public DbSet<Domain.Model.Produto> produto { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region DEPARTAMENTO

            modelBuilder.Entity<Departamento>().ToTable("DEPARTAMENTO");
            modelBuilder.Entity<Departamento>().HasKey(s => s.id);
            modelBuilder.Entity<Departamento>().Property(m => m.descricao);
            modelBuilder.Entity<Departamento>()
                .HasMany(m => m.Produtos)
                .WithOne(m => m.Departamento)
                .HasForeignKey(m => m.departamento_Id);

            #endregion

            #region PRODUTO

            modelBuilder.Entity<Domain.Model.Produto>().ToTable("PRODUTO");
            modelBuilder.Entity<Domain.Model.Produto>().HasKey(s => s.id);
            modelBuilder.Entity<Domain.Model.Produto>().Property(m => m.descricao);
            modelBuilder.Entity<Domain.Model.Produto>().Property(m => m.preco);
            modelBuilder.Entity<Domain.Model.Produto>().Property(m => m.estoque);           

            #endregion
        }
    }
}
