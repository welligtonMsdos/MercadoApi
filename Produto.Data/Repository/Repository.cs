using Microsoft.EntityFrameworkCore;
using Produto.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Produto.Data.Repository
{
    public class Repository<T> : IRepository<T>, IDisposable where T : class
    {
        protected readonly ProdutoDbContext _ctx;
        protected readonly DbSet<T> _dbSet;
        public Repository(ProdutoDbContext ctx)
        {
            _ctx = ctx;
            _dbSet = _ctx.Set<T>();
        }       

        public async Task<ICollection<T>> GetAll()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task Delete(int id)
        {
            _dbSet.Remove(await _dbSet.FindAsync(id));
            await _ctx.SaveChangesAsync();
        }

        public async Task Insert(T obj)
        {
            await _dbSet.AddAsync(obj);
            await _ctx.SaveChangesAsync();
        }

        public async Task Update(T obj)
        {
            _dbSet.Update(obj).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}
